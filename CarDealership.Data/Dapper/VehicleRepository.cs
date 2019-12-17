using CarDealership.Data.Interfaces;
using CarDealership.Models.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using System.Data;
using System.Linq;
using CarDealership.Models.ViewModels;

namespace CarDealership.Data.Dapper
{
    public class VehicleRepository : IVehicleRepository
    {

        public void VehicleMarkPurchased(int vehicleId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                // create parameter object
                var parameters = new DynamicParameters();

                parameters.Add("@VehicleId", vehicleId);

                cn.Execute("VehicleMarkPurchased",
            parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void AddVehicle(AddVehicleObject vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                // create parameter object
                var parameters = new DynamicParameters();

                parameters.Add("@VehicleId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Make", vehicle.Make);
                parameters.Add("@Model", vehicle.Model);
                parameters.Add("@Type", vehicle.Type);
                parameters.Add("@BodyStyle", vehicle.BodyStyle);
                parameters.Add("@Year", vehicle.Year);
                parameters.Add("@Transmission", vehicle.Transmission);
                parameters.Add("@Color", vehicle.Color);
                parameters.Add("@Interior", vehicle.Interior);
                parameters.Add("@Mileage", vehicle.Mileage);
                parameters.Add("@VIN", vehicle.VIN);
                parameters.Add("@MSRP", vehicle.MSRP);
                parameters.Add("@SalePrice", vehicle.SalePrice);
                parameters.Add("@Description", vehicle.Description);


                cn.Execute("AddVehicle",
            parameters, commandType: CommandType.StoredProcedure);

                vehicle.VehicleId = parameters.Get<int>("@VehicleId");
            }
        }

        public void AddVehicleFileName(string fileName, int vehicleId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                // create parameter object
                var parameters = new DynamicParameters();

                parameters.Add("@VehicleId", vehicleId);
                parameters.Add("@ImageFileName", fileName);

                cn.Execute("AddVehicleFileName",
            parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public List<FeaturedVehicleViewModel> GetFeaturedVehicleList()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                return cn.Query<FeaturedVehicleViewModel>("GetFeaturedVehicleList", commandType: CommandType.StoredProcedure).ToList();
            }
        }


        public List<VehicleDetails> GetVehicleDetailsList()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                return cn.Query<VehicleDetails>("GetVehicleDetailsList", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<VehicleInventory> GetVehicleInventoryList(string type)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                // create parameter object
                var parameters = new DynamicParameters();
                parameters.Add("@Type", type);

                return cn.Query<VehicleInventory>("GetVehicleInventoryList", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<int> GetYearList(string type)
        {


            if (!string.IsNullOrEmpty(type)) //Need either New or Old
            {
                var vehicleList = GetVehicleSearchResultList(type);
                var unsortedList = vehicleList.Select(v => v.Year).Distinct().ToList();

                var sortedList = unsortedList.OrderBy(y => y).ToList();

                return sortedList;

            }
            else
            { // Need all type Vehicles , both New and Old
                var vehicleList = GetVehicleDetailsList();
                var unsortedList = vehicleList.Select(v => v.Year).Distinct().ToList();

                var sortedList = unsortedList.OrderBy(y => y).ToList();

                return sortedList;
            }


        }

        public List<decimal> GetSalePriceList(string type)
        {

            if (!string.IsNullOrEmpty(type)) // Need either New or Old 
            {
                var salePriceList = GetVehicleSearchResultList(type);

                var unsortedList = salePriceList.Select(v => v.SalePrice).Distinct().ToList();

                var sortedList = unsortedList.OrderBy(s => s).ToList();

                var formatedList = new List<decimal>();

                foreach (var price in sortedList)
                {
                    formatedList.Add(Decimal.Truncate(price)); // Remove the decimal and leading zeroes
                }

                return formatedList;

            }

            else
            { // Need all type Vehicles , both New and Old
                var salePriceList = GetVehicleDetailsList();


                var unsortedList = salePriceList.Select(v => v.SalePrice).Distinct().ToList();

                var sortedList = unsortedList.OrderBy(s => s).ToList();

                var formatedList = new List<decimal>();

                foreach (var price in sortedList)
                {
                    formatedList.Add(Decimal.Truncate(price)); // Remove the decimal and leading zeroes
                }

                return formatedList;
            }



        }

        public List<VehicleSearchResult> GetVehicleSearchResultList(string type)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                // create parameter object
                var parameters = new DynamicParameters();
                parameters.Add("@Type", type);
                return cn.Query<VehicleSearchResult>("GetVehicleSearchResultList", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public IEnumerable<VehicleSearchResult> Search(VehicleSearchParameters parameters)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var par = new DynamicParameters();

                string query = "SELECT TOP 20 VehicleId, VIN, Interior, Transmission, Mileage, MSRP, SalePrice, Color, BodyStyle, mk.MakeName as Make, mo.ModelName as Model, [Year], ImageFileName FROM Vehicle v INNER JOIN Make mk ON v.MakeId = mk.MakeId INNER JOIN Model mo ON v.ModelId = mo.ModelId WHERE Sold = 'false' ";


                if (!string.IsNullOrEmpty(parameters.Type))
                {
                    query += "AND Type=@Type ";
                    par.Add("@Type", parameters.Type);
                }

                if (parameters.MinYear.HasValue)
                {
                    query += "AND v.Year >= @MinYear ";
                    par.Add("@MinYear", parameters.MinYear);
                }

                if (parameters.MaxYear.HasValue)
                {
                    query += "AND v.Year <= @MaxYear ";
                    par.Add("@MaxYear", parameters.MaxYear);
                }

                if (parameters.MinPrice.HasValue)
                {
                    par.Add("@MinPrice", parameters.MinPrice);
                    query += "AND v.SalePrice >= @MinPrice ";

                }

                if (parameters.MaxPrice.HasValue)
                {
                    query += "AND v.SalePrice <= @MaxPrice ";
                    par.Add("@MaxPrice", parameters.MaxPrice);
                }

                if (!string.IsNullOrEmpty(parameters.MakeModelYear))
                {
                    query += "AND (mk.MakeName LIKE @MakeModelYear OR mo.ModelName LIKE @MakeModelYear OR Year LIKE @MakeModelYear) ";
                    par.Add("@MakeModelYear", parameters.MakeModelYear + '%');
                }

                query += "ORDER BY MSRP DESC";

                return (cn.Query<VehicleSearchResult>(query, par, commandType: CommandType.Text).ToList());


            }
        }

        public VehicleDetails GetVehicleById(int? vehicleId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                // create parameter object
                var parameters = new DynamicParameters();
                parameters.Add("@VehicleId", vehicleId);
                return cn.Query<VehicleDetails>("GetVehicleById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public void UpdateVehicle(EditVehicleViewModel vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                // create parameter object
                var parameters = new DynamicParameters();

                parameters.Add("@VehicleId", vehicle.VehicleId);
                parameters.Add("@Make", vehicle.Make);
                parameters.Add("@Model", vehicle.Model);
                parameters.Add("@Type", vehicle.Type);
                parameters.Add("@BodyStyle", vehicle.BodyStyle);
                parameters.Add("@Year", vehicle.Year);
                parameters.Add("@Transmission", vehicle.Transmission);
                parameters.Add("@Color", vehicle.Color);
                parameters.Add("@Interior", vehicle.Interior);
                parameters.Add("@Mileage", vehicle.Mileage);
                parameters.Add("@VIN", vehicle.VIN);
                parameters.Add("@MSRP", vehicle.MSRP);
                parameters.Add("@SalePrice", vehicle.SalePrice);
                parameters.Add("@Description", vehicle.Description);
                parameters.Add("@FeaturedVehicle", vehicle.FeaturedVehicle);
                // no need to update ImageFileName, as it will stay the same even if the image changes

                cn.Execute("UpdateVehicle",
            parameters, commandType: CommandType.StoredProcedure);

            }
        }

        public void DeleteVehicle(int vehicleId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                // create parameter object
                var parameters = new DynamicParameters();
                parameters.Add("@VehicleId", vehicleId);

                cn.Execute("DeleteVehicle", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
