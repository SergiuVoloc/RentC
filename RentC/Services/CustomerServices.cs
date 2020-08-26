using Microsoft.IdentityModel.Protocols;
using RentC.Models;
using RepoDb;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentC.Services
{
    public class CustomerServices
    {
        // Register Customer db manipulations
        public void Create(Customers customer)
        {
            using (IDbConnection dbContext = new SqlConnection(ConfigurationManager.ConnectionStrings["RentC"].ConnectionString).EnsureOpen())
            {
                
                var newCustomer = dbContext.Insert(customer);
            }
        }

        // List Customers db manipulations
        public IEnumerable<Customers> ListAll()
        {
            using (IDbConnection dbContext = new SqlConnection(ConfigurationManager.ConnectionStrings["RentC"].ConnectionString).EnsureOpen())
            {
                return dbContext.ExecuteQuery<Customers>("select * from [dbo].[Customers];");
            }
        }
    }
}
