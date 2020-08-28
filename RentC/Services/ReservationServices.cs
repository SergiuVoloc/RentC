﻿using FluentValidation.Results;
using RentC.Helpers;
using RentC.Models;
using RepoDb;
using RepoDb.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RentC.Models.Reservations;

namespace RentC.Services
{
    public class ReservationServices
    {
        // Register Car Rent reservation db manipulations
        public void CreateReservation(Reservations reservation)
        {
            Cars car = new Cars();
            Customers customer = new Customers();
            PrintColorMessage colorMessage = new PrintColorMessage();
            //Reservations testReservations = new Reservations();
            ReservationValidator validator = new ReservationValidator();
            ValidationResult result = validator.Validate(reservation);

            // Input Customer Name Validation
            if (!result.IsValid){
                colorMessage.Print(ConsoleColor.Red, "\nReservation is not created! See reason below:");

                //data validation
                foreach (var failure in result.Errors){
                    Console.WriteLine("\n '" + failure.PropertyName + "' written incorrectly . \n Details: " + failure.ErrorMessage);
                }
            }
            else
            {
                using (IDbConnection dbContext = new SqlConnection(ConfigurationManager.ConnectionStrings["RentC"].ConnectionString).EnsureOpen())
                {
                    // database insertion of the new customer 
                    try
                    {
                        var newCarRent = dbContext.Insert(reservation);
                        colorMessage.Print(ConsoleColor.Yellow, "\n Reservation created succesffuly!");
                    }
                    // Birth Date range validation
                    catch (System.Data.SqlTypes.SqlTypeException)
                    {
                        Console.WriteLine(" \n'Birth Date' should be between:1/1/1753 and 12/31/2020");

                    }
                }
            }
        }
        //    using (IDbConnection dbContext = new SqlConnection(ConfigurationManager.ConnectionStrings["RentC"].ConnectionString).EnsureOpen())
        //    {

        //        // validation test
               


        //        //testReservations = dbContext.Query<Reservations>(e => e.CustomerID == customer.CustomerID).FirstOrDefault();

        //        //Console.WriteLine(testReservations);

        //        //Insert into testing(id, item_name)Select 1,'Book' From Dual Where 1 = 1;
        //        //Insert into dummy1(id, name)select id, name from dummy Where id = 1;
        //    }
        //}



        public void UpdateReservation(Reservations reservation)
        {
            Cars car = new Cars();
            ReservationValidator validator = new ReservationValidator();
            ValidationResult result = validator.Validate(reservation);
            PrintColorMessage colorMessage = new PrintColorMessage();


            // Input Customer Name Validation
            if (!result.IsValid)
            {
                colorMessage.Print(ConsoleColor.Red, "\nReservation is not Updated! See reason below:");

                //data validation
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine("\n '" + failure.PropertyName + "' written incorrectly . \n Details: " + failure.ErrorMessage);
                }
            }
            else
            {
                using (IDbConnection dbContext = new SqlConnection(ConfigurationManager.ConnectionStrings["RentC"].ConnectionString).EnsureOpen())
                {
                    // database data Update 
                    try
                    {
                        var affectedRows = dbContext.ExecuteQuery("UPDATE [dbo].[Reservations] SET  StartDate = @startDate, EndDate = @endDate WHERE Id = @Id;", new
                        {
                            updatedPlate = car.Plate,
                            startDate = reservation.StartDate,
                            endDate = reservation.EndDate
                        });






                    }
                    // Birth Date range validation
                    catch (System.Data.SqlTypes.SqlTypeException)
                    {
                        Console.WriteLine(" \n'Birth Date' should be between:1/1/1753 and 12/31/2020");

                    }
                }
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



        public IEnumerable<Reservations> ListAvailableCars()
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

               
                var extractor = dbContext.ExecuteQueryMultiple("SELECT Cars.Plate, Cars.Model, Reservations.StartDate, Reservations.EndDate, Reservations.Location FROM  Reservations INNER JOIN Cars ON Cars.CarID = Reservations.CarID");
                var cars = extractor.Extract<Cars>().AsList();
                var reservations = extractor.Extract<Reservations>().AsList();


                reservations.ForEach(reservation =>
                    reservation.CarID = cars.Where(o => o.CarID == reservation.CarID).AsList()
                );
                Console.WriteLine(reservations);
                return reservations;


        }

        }
    }
}
