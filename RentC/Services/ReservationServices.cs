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
    public class ReservationServices
    {
        // Register Car Rent reservation db manipulations
        public void CreateReservation(Reservations reservation)
        {
            using (IDbConnection dbContext = new SqlConnection(ConfigurationManager.ConnectionStrings["RentC"].ConnectionString).EnsureOpen())
            {

                // validation test
                Cars car = new Cars();
                Reservations testReservations = new Reservations();
                Customers customer = new Customers();


                //testReservations = dbContext.Query<Reservations>(e => e.CustomerID == customer.CustomerID).FirstOrDefault();

                //Console.WriteLine(testReservations);

                var newCarRent = dbContext.Insert(reservation);
                

                //Insert into testing(id, item_name)Select 1,'Book' From Dual Where 1 = 1;
                //Insert into dummy1(id, name)select id, name from dummy Where id = 1;
            }
        }



        // List Customers db manipulations
        public IEnumerable<Reservations> ListAll()
        {
            using (IDbConnection dbContext = new SqlConnection(ConfigurationManager.ConnectionStrings["RentC"].ConnectionString).EnsureOpen())
            {
                return dbContext.ExecuteQuery<Reservations>("SELECT Cars.Plate, Customers.CustomerID, StartDate, EndDate, Reservations.Location FROM  Reservations INNER JOIN Customers ON Customers.CustomerID = Reservations.CustomerID INNER JOIN Cars ON Cars.CarID = Reservations.CarID");
            }
        }



        public IEnumerable<Cars> ListAvailableCars()
        {
            using (IDbConnection dbContext = new SqlConnection(ConfigurationManager.ConnectionStrings["RentC"].ConnectionString).EnsureOpen())
            {
                //Console.Write("Car Plate: ");
                //var searchPlate = Console.ReadLine();

                //Console.Write("Car Model: ");
                //var searchModel = Console.ReadLine();

                //Console.Write("Start Date: ");
                //var searchStartDate = Convert.ToDateTime(Console.ReadLine());

                //Console.Write("End Date: ");
                //var searchEndDate = Convert.ToDateTime(Console.ReadLine());

                //Console.Write("Location: ");
                //var searchLocation = Console.ReadLine();

                return dbContext.ExecuteQuery<Cars>(" SELECT Cars.Plate, Cars.Model, Reservations.StartDate, Reservations.EndDate, Reservations.Location FROM  Reservations INNER JOIN Cars ON Cars.CarID = Reservations.CarID");
            }

        }
    }
}
