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
    public static class VehicleRepositoryFactory
    {
        public static IVehicleRepository GetVehicleRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "PROD":
                    return new VehicleRepository();
                case "QA":
                    return new VehicleRepositoryQA();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value");
            }
        }
    }
}
