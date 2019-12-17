using CarDealership.Data.Dapper;
using CarDealership.Data.Interfaces;
using CarDealership.Data.QARepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Factories
{
    public class ModelRepositoryFactory
    {
        public static IModelRepository GetModelRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "PROD":
                    return new ModelRepository();
                case "QA":
                    return new ModelRepositoryQA();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value");
            }
        }
    }
}
