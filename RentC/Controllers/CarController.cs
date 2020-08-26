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
    public class CarController
    {
        CarService carService = new CarService();
        PrintColorMessage printColorMessage = new PrintColorMessage();
        Navigation navigation = new Navigation();

        // Method tor Register New Car Rent Screen logic
        public void RegisterNewCarRent()
        {
            Console.Clear();

            Cars car = new Cars();
            Reservations reservations = new Reservations();

            Console.Write("Plate: "); car.Plate = Console.ReadLine();
            Console.Write("Manufacturer: "); car.Manufacturer = Console.ReadLine();
            Console.Write("Model: "); car.Model = Console.ReadLine();
            Console.Write("Price per day: "); car.PricePerDay = Convert.ToInt32(Console.ReadLine());
            Console.Write("Location: "); car.Location = Console.ReadLine();
            //Reservation std = new Reservation();
            //car.CarID = Console.ReadLine();

            // Validations
            //if (car.Model )
            //{

            //}

            carService.Create(car);

        }

        public void UpdateCarRent()
        {

        }


        public void ListRents()
        {

        }


        public void ListAvaiableCars()
        {

        }




    }
}
