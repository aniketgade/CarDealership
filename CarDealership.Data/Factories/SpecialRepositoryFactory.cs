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
    public class SpecialRepositoryFactory
    {
        public static ISpecialRepository GetSpecialRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "PROD":
                    return new SpecialRepository();
                case "QA":
                    return new SpecialRepositoryQA();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value");
            }
        }
    }
}
