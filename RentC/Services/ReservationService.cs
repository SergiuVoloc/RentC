using FluentValidation.Results;
using Newtonsoft.Json;
using RentC.Helpers;
using RentC.Models;
using RentC_ConsoleApplication.DbContexts;
using RepoDb;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using static RentC.Models.Reservation;


namespace RentC.Services
{
    public class ReservationService
    {
        // Register Car Rent reservation database manipulations
        public void CreateReservation(Reservation reservation)
        {
            Car car = new Car();
            Customers customer = new Customers();
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
                //EF
                using (var context = new ReservationDbContext())
                {
                    try
                    {
                        context.Reservations.Add(reservation);
                        context.SaveChanges();

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
                using (var context = new ReservationDbContext())
                {
                    var reservationToUpdate = context.Reservations.First(x => x.ReservationID == reservation.ReservationID);
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
            using (var context = new ReservationDbContext())
            {
                var result = context.Reservations.ToList();

                return result;
            }
        }




        // List Available Cars database manipulations
        public string ListAvailableCars()
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


                // Web Service utilisation
                RentC_ConsoleApplication.localhost.WebService2 webService = new RentC_ConsoleApplication.localhost.WebService2();
                HttpClient httpClient = new HttpClient();
                //string availableCarsJson = webService.ListAvailableCars();
                //WebServicesSettings(httpClient);
                //HttpResponseMessage message = httpClient.GetAsync("ListAvailableCars").Result;
                
                //var reservationJson = message.Content.ReadAsStringAsync().Result;

                //var resultJson = splitString(reservationJson).ToString();

                //Console.WriteLine(resultJson);

                var test = webService.ListAvailableCars();

                return test;
            }
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
