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
    public class CustomerController
    {

        // Method tor Register New Customer Screen logic
        public void RegisterNewCustomer()
        {
            CustomerServices customerServices = new CustomerServices();
            PrintColorMessage printColorMessage = new PrintColorMessage();
            Navigation navigation = new Navigation();
            Customers customer = new Customers();

            Console.Clear();
            Console.Write("Name: "); customer.Name = Console.ReadLine();
            Console.Write("Birth Date: "); customer.BirthDate = Convert.ToDateTime(Console.ReadLine());
            customerServices.Create(customer);
            /* Console.Write("Name: "); var tmpName = Console.ReadLine();
             Console.Write("Birth Date: "); var tmpBirthDate = Convert.ToDateTime(Console.ReadLine());
             Console.Write("Zip Code: "); var tmpZipCode = Convert.ToInt32(Console.ReadLine());
             Customers std = new Customers{ Name=tmpName, BirthDate=tmpBirthDate, ZipCode=tmpZipCode };
            cs.New(std);*/

            printColorMessage.Print(ConsoleColor.Yellow, "Customer inserted succesffuly!");

            navigation.GoToMenu();
        }



        // Method tor List Customers screen logic
        public void ListCustomers()
        {
            CustomerServices customerServices = new CustomerServices();
            Navigation navigation = new Navigation();

            Console.Clear();
            Console.WriteLine("CustomerID \tName \t\t\tBirth date ");
            foreach (var customer in customerServices.ListAll())
            {
                Console.WriteLine("\t{0} \t{1} \t\t{2}",
                    customer.CustomerID,
                    customer.Name,
                    customer.BirthDate);
            }
            navigation.GoToMenu();
        }



        public void UpdateCustomer()
        {

        }
    }
}
