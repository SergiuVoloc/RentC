using RentC.Helpers;
using RentC.Models;
using RentC.Services;
using RepoDb;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentC.Controllers
{
    public class CustomerController
    {

        // Method for Register New Customer Screen logic
        public void RegisterNewCustomer()
        {
            CustomerService customerServices = new CustomerService();
            PrintColorMessage colorMessage = new PrintColorMessage();
            Navigation navigation = new Navigation();
            Customer customer = new Customer();

            Console.Clear();

            customer.CustomerID = customer.CustomerID;

            Console.Write("Name: ");
            customer.Name = Console.ReadLine();

            Console.Write("Birth Date: ");

            // Birth Date format validation
            try
            {
                customer.BirthDate = Convert.ToDateTime(Console.ReadLine());
            }
            catch (Exception e)
            {
                if ( e is System.FormatException)
                {
                    colorMessage.Print(ConsoleColor.Red, "\n 'Birth Date' written incorrectly.");
                    Console.WriteLine("\n Details: The format should be: dd-MM-yyyy");
                }
                
            }

            customerServices.Create(customer);

            navigation.GoToMenu();

        }




        // Method for List Customers screen logic
        public void ListCustomers()
        {
            CustomerService customerServices = new CustomerService();
            Navigation navigation = new Navigation();

            Console.Clear();
            Console.WriteLine("CustomerID \tName \t\t\tBirth date ");
            foreach (var customer in customerServices.ListAll())
            {
                Console.WriteLine("\n\t{0} \t{1} \t\t{2}",
                    customer.CustomerID,
                    customer.Name,
                    customer.BirthDate);
            }
            navigation.GoToMenu();
        }




        // Method for Update Customers screen logic
        public void UpdateCustomer()
        {
            Console.Clear();

            PrintColorMessage colorMessage = new PrintColorMessage();
            CustomerService customerServices = new CustomerService();
            Customer customer = new Customer();
            Navigation navigation = new Navigation();

            Console.Write("Customer ID: ");
            customer.CustomerID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Name: ");
            customer.Name = Console.ReadLine();

            Console.Write("Birth Date: ");
            customer.BirthDate = Convert.ToDateTime(Console.ReadLine());

            customerServices.Update(customer);

            colorMessage.Print(ConsoleColor.Yellow, "Customer Updated succesffuly!");
            navigation.GoToMenu();
        }
    }
}
