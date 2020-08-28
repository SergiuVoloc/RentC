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
        ReservationController reservation = new ReservationController();
        PrintColorMessage colorMessage = new PrintColorMessage();
        
        

        private string PageTitle = "Menu";
        public void Index() {

            Console.Clear();
            Console.WriteLine("\t\n <---   " + this.PageTitle + "   --->");
            Console.WriteLine("\t\n 1. Register new Rent ");
            Console.WriteLine("\t\n 2. Update Car Rent");
            Console.WriteLine("\t\n 3. List Rents");
            Console.WriteLine("\t\n 4. List Available Cars");
            Console.WriteLine("\t\n 5. Register new Customer");
            Console.WriteLine("\t\n 6. Update Customer");
            Console.WriteLine("\t\n 7. List Customers");
            Console.WriteLine("\t\n 8. Quit");
            colorMessage.Print(ConsoleColor.Yellow, "\n\t< ---Enter Your desired option--->");

            var option = 0;
            switch (option = Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    reservation.RegisterNewCarRent();
                    break;
                case 2:
                    reservation.UpdateReservaion();
                    break;
                case 3:
                    reservation.ListRents();
                    break;
                case 4:
                    reservation.ListAvaiableCars();
                    break;
                case 5:
                    customer.RegisterNewCustomer();
                    break;
                case 6:
                    customer.UpdateCustomer();
                    break;
                case 7:
                    customer.ListCustomers();
                    break;
                case 8:
                    { }
                    break;
                default:
                    colorMessage.Print(ConsoleColor.Red,"\n\tThis is not a valid option. Choose from 1 to 8 ");

                    Navigation navigation = new Navigation();
                    Menu menu = new Menu();

                    navigation.GoToMenu("\n\tPress ENTER to type a valid option or ESC to quit");
                    menu.Index();
                    break;
            }
        }
    }
}
