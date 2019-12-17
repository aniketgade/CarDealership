using CarDealership.Data.Interfaces;
using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Dapper
{
    public class SaleLogRepository : ISaleLogRepository
    {
        public void AddSaleLog(SaleLog saleLog)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                // create parameter object
                var parameters = new DynamicParameters();

                parameters.Add("@BuyerName", saleLog.BuyerName);
                parameters.Add("@Email", saleLog.Email);
                parameters.Add("@Street1", saleLog.Street1);
                parameters.Add("@Street2", saleLog.Street2);
                parameters.Add("@City", saleLog.City);
                parameters.Add("@State", saleLog.State);
                parameters.Add("@ZipCode", saleLog.ZipCode);
                parameters.Add("@PurchasePrice", saleLog.PurchasePrice);
                parameters.Add("@PurchaseType", saleLog.PurchaseType);
                parameters.Add("@VehicleId", saleLog.VehicleId);
                parameters.Add("@Phone", saleLog.Phone);
                parameters.Add("@SalesUserId", saleLog.SalesUserId);
                parameters.Add("@PurchaseDate", saleLog.PurchaseDate);


                cn.Execute("AddSaleLog",
            parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public List<SaleLog> GetAllSales()
        {
            throw new NotImplementedException();
        }

        public List<UserSaleObject> Search(InventorySearchParameters parameters)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var par = new DynamicParameters();

                string query = "SELECT FirstName + ' ' + LastName as [User], SUM(PurchasePrice) AS 'TotalSales', COUNT(SalesUserId) AS 'TotalVehicles' FROM SaleLog s INNER JOIN AspNetUsers u ON s.SalesUserId = u.Id  WHERE 1=1 ";


                if (!string.IsNullOrEmpty(parameters.UserId))
                {
                    query += "AND u.Id=@UserId ";
                    par.Add("@UserId", parameters.UserId);
                }

                if (parameters.FromDate.HasValue && !parameters.ToDate.HasValue)
                {
                    query += "AND PurchaseDate >= @FromDate ";
                    par.Add("@FromDate", parameters.FromDate);
                }

                if (!parameters.FromDate.HasValue && parameters.ToDate.HasValue)
                {
                    query += "AND PurchaseDate <= @ToDate ";
                    par.Add("@ToDate", parameters.ToDate);
                }

                if (parameters.FromDate.HasValue && parameters.ToDate.HasValue)
                {
                    query += "AND PurchaseDate BETWEEN @FromDate AND @ToDate ";
                    par.Add("@FromDate", parameters.FromDate);
                    par.Add("@ToDate", parameters.ToDate);
                }

                query += "GROUP BY FirstName, LastName";

                return (cn.Query<UserSaleObject>(query, par, commandType: CommandType.Text).ToList());


            }
        }
    }
}
