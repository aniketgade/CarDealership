using CarDealership.Data.Interfaces;
using CarDealership.Models.Tables;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Dapper
{
    public class ContactRepository : IContactRepository
    {
        public void AddContact(Contact contact)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                // create parameter object
                var parameters = new DynamicParameters();

                parameters.Add("@Name", contact.Name);
                parameters.Add("@Email", contact.Email);
                parameters.Add("@Phone", contact.Phone);
                parameters.Add("@Message", contact.Message);


                cn.Execute("AddContact",
            parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
