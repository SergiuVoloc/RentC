using Microsoft.Build.Framework.XamlTypes;
using Newtonsoft.Json;
using RentC_ConsoleApplication.Helpers;
using RentC_ConsoleApplication.Models;
using RentC_ConsoleApplication.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RentC_ConsoleApplication.Controllers
{
    public class ReservationController
    {

        // Method for Register New Car Rent Screen logic
        public void RegisterNewCarRent()
        {
            Console.Clear();

            Car car = new Car();
            PrintColorMessage printColorMessage = new PrintColorMessage();
            ReservationService reservationServices = new ReservationService();
            Customer customer = new Customer();
            Reservation reservation = new Reservation();
            Navigation navigation = new Navigation();

            Console.Write("Car Plate: ");
            reservation.CarPlate = Console.ReadLine();

            Console.Write("Car ID: ");
            reservation.CarID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Customer ID: ");
            reservation.CustomerID = Convert.ToInt32(Console.ReadLine());

            reservation.ReservStatsID = 1;

            Console.Write("Start Date: ");
            reservation.StartDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("End Date: ");
            var endDate = Console.ReadLine();
            reservation.EndDate = Convert.ToDateTime(endDate);

            Console.Write("Location: ");
            reservation.Location = Console.ReadLine();

            reservationServices.CreateReservation(reservation);

            navigation.GoToMenu();
        }



        // Method for Update Car Rent Screen logic
        public void UpdateReservaion()
        {
            Console.Clear();

            Car car = new Car();
            PrintColorMessage printColorMessage = new PrintColorMessage();
            ReservationService reservationServices = new ReservationService();
            Customer customer = new Customer();
            Reservation reservation = new Reservation();
            Navigation navigation = new Navigation();


            Console.Write("Reservation ID:");
            reservation.ReservationID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Car Plate: ");
            reservation.CarPlate = Console.ReadLine();

            Console.Write("Start Date: ");
            reservation.StartDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("End Date: ");
            reservation.EndDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Location: ");
            reservation.Location = Console.ReadLine();

            reservationServices.UpdateReservation(reservation);

            printColorMessage.Print(ConsoleColor.Yellow, "Reservation Updated succesffuly!");
            navigation.GoToMenu();
        }




        // Method for List Reservations screen logic
        public void ListRents()
        {
            Car car = new Car();
            ReservationService reservationServices = new ReservationService();
            Navigation navigation = new Navigation();

            Console.Clear();
            var reservations = reservationServices.ListAll();
            Console.WriteLine("\t<---------------- All Reservations ------------------>");
            Console.WriteLine("\n ID  Car Plate  CustomerID      Start Date     End Date            Location");
            foreach (var reservation in reservations)
            {
                var message = $"\n {reservation.ReservationID}   {reservation.CarPlate}    {reservation.CustomerID}        {reservation.StartDate}    {reservation.EndDate}   {reservation.Location}";
                Console.WriteLine(message);
            }
            navigation.GoToMenu();
        }





        // Method for List Available Cars Screen logic
        public void ListAvaiableCars()
        {
            
            ReservationService reservationServices = new ReservationService();
            Navigation navigation = new Navigation();
            Car car = new Car();
            string searchedPlate = car.Plate;
            string searchedModel = car.Model;


            Console.Clear();
            Console.WriteLine("Car Plate \tCar Model \tStart date \tEnd date \tLocation");

            reservationServices.ListAvailableCars();
            //foreach (var item in reservationServices.ListAvailableCars())
            //{
            //    Console.WriteLine(" {0} \t{1} \t{2} \t{3} \t{4}",
            //        searchedPlate,
            //        searchedModel,
            //        item.StartDate,
            //        item.EndDate,
            //        item.Location);
            //}

            navigation.GoToMenu();
        }







       

    }
}
