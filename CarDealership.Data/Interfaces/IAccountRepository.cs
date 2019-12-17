using CarDealership.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interfaces
{
    public interface IAccountRepository
    {
        List<UserQuery> GetUserList();

        List<UserSaleObject> GetUserSaleList();

        string GetUserEmail(string userId);
    }
}
