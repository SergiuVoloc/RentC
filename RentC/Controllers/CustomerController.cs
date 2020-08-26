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
        CustomerServices customerServices = new CustomerServices();
        PrintColorMessage printColorMessage = new PrintColorMessage();
        Navigation navigation = new Navigation();

        // Method tor Register New Customer Screen logic
        public void RegisterNewCustomer()
        {
            Console.Clear();
            Customers customer = new Customers();
            Console.Write("Name: "); customer.Name = Console.ReadLine();
            Console.Write("Birth Date: "); customer.BirthDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Location: "); customer.Location = Console.ReadLine();
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
            Console.Clear();
            Console.WriteLine("CustomerID \tName \t\tBirth date \t\tZip code");
            foreach (var customer in customerServices.ListAll())
            {
                Console.WriteLine("\t{0} \t{1} \t{2}\t{3}",
                    customer.CustomerID,
                    customer.Name,
                    customer.BirthDate,
                    customer.Location);
            }
            navigation.GoToMenu();
        }
    }
}
