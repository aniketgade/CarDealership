using CarDealership.Data.Interfaces;
using CarDealership.Models.Tables;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Dapper
{
    public class SpecialRepository : ISpecialRepository
    {
        public void AddSpecial(Special special)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                // create parameter object
                var parameters = new DynamicParameters();

                parameters.Add("@Title", special.Title);
                parameters.Add("@Description", special.Description);
                
                cn.Execute("AddSpecial",
            parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public List<Special> GetSpecials()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                return cn.Query<Special>("GetSpecials", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void DeleteSpecial(int id)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                // create parameter object
                var parameters = new DynamicParameters();
                parameters.Add("@SpecialId", id);

                cn.Execute("DeleteSpecial", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
