using FluentValidation.Results;
using Newtonsoft.Json;
using RentC_ConsoleApplication.Helpers;
using RentC_DbConnection;
using RentC_DbConnection.Models;
using RepoDb;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using static RentC_DbConnection.Models.Reservation;

namespace RentC_ConsoleApplication.Services
{
    public class ReservationService
    {

        // Register Car Rent reservation database manipulations
        public void CreateReservation(Reservation reservation)
        {

            PrintColorMessage colorMessage = new PrintColorMessage();
            Navigation navigation = new Navigation();
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
               
                using (var context = new ApplicationDbContext())
                {
                    try
                    {
                        context.Reservations.Add(reservation);

                        try
                        {
                            context.SaveChanges();
                        }
                        catch (SqlException)
                        {
                            colorMessage.Print(ConsoleColor.Red, "Error: CustomerID should exist in the Customer table");

                        }

                        colorMessage.Print(ConsoleColor.Yellow, "Reservation created succesffuly!");
                        navigation.GoToMenu();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }


                }
            }
        }




        // Update Reservation database manipulations
        public void UpdateReservation(Reservation reservation)
        {
            Car car = new Car();
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
                //EF
                using (var context = new ApplicationDbContext())
                {
                    var reservationToUpdate = 
                        context.Reservations.First(x => x.ReservationID == reservation.ReservationID);
                    reservationToUpdate.CarPlate = reservation.CarPlate;
                    reservationToUpdate.StartDate = reservation.StartDate;
                    reservationToUpdate.EndDate = reservation.EndDate;
                    reservationToUpdate.Location = reservation.Location;


                    context.SaveChanges();
                }
            }
        }




        // List Reservations database manipulations
        public IEnumerable<Reservation> ListAll()
        {
            //EF
            using (var context = new ApplicationDbContext())
            {
                var result = context.Reservations.ToList();

                return (IEnumerable<Reservation>)result;
            }
        }




        // List Available Cars database manipulations
        public string ListAvailableCars()
        {
           

            // Web Service utilisation
            RentC_ConsoleApplication.localhost.WebService2 webService = new RentC_ConsoleApplication.localhost.WebService2();

           

            var car = webService.ListAvailableCars();

            JsonConvert.DeserializeObject(car).ToString();
            return car;
        
        }

        private static void WebServicesSettings(HttpClient httpClient)
        {

            httpClient.BaseAddress = new Uri("https://localhost:44393/WebService2.asmx/");
        }

        private DataTable splitString(string reservationJson)
        {
            string[] json = reservationJson.Split('>');
            string[] finalJson = json[2].Split('<');

            DataTable result = JsonConvert.DeserializeObject<DataTable>(finalJson[0]);
            return result;
        }

    }
}
