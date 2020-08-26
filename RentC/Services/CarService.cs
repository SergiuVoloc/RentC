using RentC.Models;
using RepoDb;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentC.Services
{
    public class CarService
    {
        // Register Car Rent reservation db manipulations
        public void Create(Cars car)
        {
            using (IDbConnection dbContext = new SqlConnection(ConfigurationManager.ConnectionStrings["RentC"].ConnectionString).EnsureOpen())
            {

                var newCar = dbContext.Insert(car);


                //Insert into testing(id, item_name)Select 1,'Book' From Dual Where 1 = 1;
                //Insert into dummy1(id, name)select id, name from dummy Where id = 1;
            }
        }




    }
}
