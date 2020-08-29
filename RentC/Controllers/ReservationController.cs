using RentC.Helpers;
using RentC.Models;
using RentC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentC.Controllers
{
    public class ReservationController
    {

        // Method tor Register New Car Rent Screen logic
        public void RegisterNewCarRent()
        {
            Console.Clear();

            Cars car = new Cars();
            PrintColorMessage printColorMessage = new PrintColorMessage();
            ReservationServices reservationServices = new ReservationServices();
            Customers customer = new Customers();
            Reservations reservation = new Reservations();

            Console.Write("Car Plate: "); 
            car.Plate = Console.ReadLine();

            Console.Write("Customer ID: ");
            reservation.CustomerID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Start Date: ");
            reservation.StartDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("End Date: ");
            reservation.EndDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Location: ");
            reservation.Location = Console.ReadLine();

            reservationServices.CreateReservation(reservation);

            printColorMessage.Print(ConsoleColor.Yellow, "Reservation created succesffuly!");

        }



        // Method tor Update Car Rent Screen logic
        public void UpdateReservaion()
        {
            Console.Clear();

            Cars car = new Cars();
            PrintColorMessage printColorMessage = new PrintColorMessage();
            ReservationServices reservationServices = new ReservationServices();
            Customers customer = new Customers();
            Reservations reservation = new Reservations();
            Navigation navigation = new Navigation();

            Console.Write("Car Plate: ");
            car.Plate = Console.ReadLine();

            Console.Write("Customer ID: ");
            reservation.CustomerID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Start Date: ");
            reservation.StartDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("End Date: ");
            reservation.EndDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Location: ");
            reservation.Location = Console.ReadLine();

            reservationServices.UpdateReservation(reservation);

            printColorMessage.Print(ConsoleColor.Yellow, "Reservation Updated succesffuly!");
            navigation.GoToMenu();
        }


        // Method tor List Rents screen logic
        public void ListRents()
        {
            Cars car = new Cars();
            ReservationServices reservationServices = new ReservationServices();
            Navigation navigation = new Navigation();
            Reservations reservation = new Reservations();

            Console.Clear();
            reservationServices.ListAvailableCars();
            /*foreach (var searchCar in reservationServices.ListAvailableCars())
            {
                Console.WriteLine(" {0} \t{1} \t{2}\t{3}",
                    searchCar.Plate,
                    searchCar.Model,
                    reservation.StartDate,
                    reservation.EndDate,
                    reservation.Location);
            }*/
            navigation.GoToMenu();
        }




        // Method tor List Available Cars Screen logic
        public void ListAvaiableCars()
        {
            ReservationServices reservationServices = new ReservationServices();
            Navigation navigation = new Navigation();
            

            Console.Clear();
            Console.WriteLine("Car Plate \tCar Model \tStart date \tEnd date \tLocation");
            reservationServices.ListAvailableCars();
            foreach (var item in reservationServices.ListAvailableCars())
            {
                Console.WriteLine(" {0} \t{1} \t{2} \t{3} \t{4}",
                    item.Cars,
                    item.StartDate,
                    item.EndDate,
                    item.Location);
            }
            navigation.GoToMenu();
        }




    }
}
