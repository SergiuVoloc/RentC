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

        // Method for Register New Customer Screen logic
        public void RegisterNewCustomer()
        {
            CustomerServices customerServices = new CustomerServices();
            PrintColorMessage colorMessage = new PrintColorMessage();
            Navigation navigation = new Navigation();
            Customers customer = new Customers();

            Console.Clear();

            Console.Write("Customer ID: ");
            customer.CustomerID = Convert.ToInt32(Console.ReadLine());

            //return error if ID is already used, if not create new one
            //public async Task<bool> IsIdListValid(IEnumerable<int> idList)
            //{
            //    var validIds = await _context.Foo.Select(x => x.Id).ToListAync();
            //    return idList.All(x => validIds.Contains(x));
            //}
            //IsIdListValid(customer.CustomerID);



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

            colorMessage.Print(ConsoleColor.Yellow, "Customer ID is: {0}");

            navigation.GoToMenu();
        }



        // Method for List Customers screen logic
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



        // Method for Update Customers screen logic
        public void UpdateCustomer()
        {
            Console.Clear();

            PrintColorMessage colorMessage = new PrintColorMessage();
            CustomerServices customerServices = new CustomerServices();
            Customers customer = new Customers();
            Navigation navigation = new Navigation();

            Console.Write("Customer ID: ");
            customer.CustomerID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Name: ");
            customer.Name = Console.ReadLine();

            Console.WriteLine("Birth Date: ");
            customer.BirthDate = Convert.ToDateTime(Console.ReadLine());

            customerServices.Update(customer);

            colorMessage.Print(ConsoleColor.Yellow, "Customer Updated succesffuly!");
            navigation.GoToMenu();
        }
    }
}
