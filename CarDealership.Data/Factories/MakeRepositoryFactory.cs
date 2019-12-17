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
    public class MakeRepositoryFactory
    {
        public static IMakeRepository GetMakeRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "PROD":
                    return new MakeRepository();
                case "QA":
                    return new MakeRepositoryQA();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value");
            }
        }
    }
}
