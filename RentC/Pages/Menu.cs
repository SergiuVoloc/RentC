using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using RentC.Models;
using RepoDb;
using RentC.Helpers;
using RentC.Services;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using RentC.Controllers;

namespace RentC.Pages
{
    class Menu
    {
        CustomerController customer = new CustomerController();
        CarController car = new CarController();

        private string PageTitle = "Menu";
        public void Index() {

            Console.Clear();
            Console.WriteLine("<---   " + this.PageTitle + "   --->");
            Console.WriteLine("1. Register new Rent ");
            Console.WriteLine("2. Update Car Rent");
            Console.WriteLine("3. List Rents");
            Console.WriteLine("4. List Available Cars");
            Console.WriteLine("5. Register new Customer");
            Console.WriteLine("6. Update Customer");
            Console.WriteLine("7. List Customers");
            Console.WriteLine("8. Quit");

            switch (Console.ReadLine())
            {
                case "1":
                    car.RegisterNewCarRent();
                    break;
                case "2":
                    car.UpdateCarRent();
                    break;
                case "3":
                    car.ListAvaiableCars();
                    break;
                case "4":
                    car.ListRents();
                    break;
                case "5":
                    customer.RegisterNewCustomer();
                    break;
                case "6":
                    //ListCustomers();
                    break;
                case "7":
                    customer.ListCustomers();
                    break;
                case "8":
                    { }
                    break;
            }
        }
    }
}
