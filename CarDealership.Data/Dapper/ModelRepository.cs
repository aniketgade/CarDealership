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
    public class ModelRepository : IModelRepository
    {
        public void AddModel(Model model)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                // create parameter object
                var parameters = new DynamicParameters();

                parameters.Add("@ModelName", model.ModelName);
                parameters.Add("@DateAdded", model.DateAdded);
                parameters.Add("@UserId", model.UserId);
                parameters.Add("@MakeId", model.MakeId);

                cn.Execute("AddModel",
            parameters, commandType: CommandType.StoredProcedure);
            }
        }


        public List<string> GetModelsByMake(string makeName)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                // create parameter object
                var parameters = new DynamicParameters();
                parameters.Add("@MakeName", makeName);

                return cn.Query<string>("GetModelsByMake", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public string GetModelById(int modelId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                // create parameter object
                var parameters = new DynamicParameters();
                parameters.Add("@ModelId", modelId);

                return cn.Query<string>("GetModelById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<string> GetModelNames()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                return cn.Query<string>("GetModelNames", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<AddModelViewModel> GetAllModelDetails()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                return cn.Query<AddModelViewModel>("GetAllModelDetails", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int GetModelIdByName(string model) // This method implementation is only needed for QA Repo
        {
            throw new NotImplementedException();
        }

        public List<Model> GetAllModels()
        {
            throw new NotImplementedException();
        }
    }
}
