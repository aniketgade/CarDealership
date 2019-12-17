using CarDealership.Data.Interfaces;
using CarDealership.Models.Tables;
using CarDealership.Models.ViewModels;
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
    public class MakeRepository : IMakeRepository
    {
        public void AddMake(Make make)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                // create parameter object
                var parameters = new DynamicParameters();

                parameters.Add("@MakeName", make.MakeName);
                parameters.Add("@DateAdded", make.DateAdded);
                parameters.Add("@UserId", make.UserId);
                
                cn.Execute("AddMake",
            parameters, commandType: CommandType.StoredProcedure);
            }
        }


        public string GetMakeById(int makeId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                // create parameter object
                var parameters = new DynamicParameters();
                parameters.Add("@MakeId", makeId);

                return cn.Query<string>("GetMakeById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public int GetMakeIdByName(string makeName)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                // create parameter object
                var parameters = new DynamicParameters();
                parameters.Add("@MakeName", makeName);

                return cn.Query<int>("GetMakeIdByName", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<string> GetMakeNames()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                return cn.Query<string>("GetMakeNames", commandType: CommandType.StoredProcedure).ToList();
            }
        }


        public List<MakeViewModel> GetMakeDetails()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                return cn.Query<MakeViewModel>("GetMakeDetails", commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
