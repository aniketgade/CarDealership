using CarDealership.Data.Interfaces;
using CarDealership.Models.Queries;
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
    public class AccountRepository : IAccountRepository
    {
        public string GetUserEmail(string userId)
        {
            throw new NotImplementedException();
        }

        public List<UserQuery> GetUserList()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                return cn.Query<UserQuery>("GetUserList", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<UserSaleObject> GetUserSaleList()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                return cn.Query<UserSaleObject>("GetUserSaleList", commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
