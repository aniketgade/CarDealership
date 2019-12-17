using CarDealership.Data.Interfaces;
using CarDealership.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.QARepositories
{
    public class AccountRepositoryQA : IAccountRepository
    {
        public string GetUserEmail(string userId)
        {
            throw new NotImplementedException();
        }

        public List<UserQuery> GetUserList()
        {
            throw new NotImplementedException();
        }

        public List<UserSaleObject> GetUserSaleList()
        {
            throw new NotImplementedException();
        }
    }
}
