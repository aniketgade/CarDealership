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
    public class ContactRepositoryFactory
    {
        public static IContactRepository GetContactRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "PROD":
                    return new ContactRepository();
                case "QA":
                    return new ContactRepositoryQA();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value");
            }
        }
    }
}
