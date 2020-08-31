using FluentValidation.Results;
using RentC.Helpers;
using RentC.Models;
using RentC_ConsoleApplication.DbContexts;
using RepoDb;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RentC.Models.Customer;
using static RentC.Models.Customer;

namespace RentC.Services
{
    public class CustomerService
    {


        // Register Customer db manipulations
        public void Create(Customer customer)
        {
            PrintColorMessage colorMessage = new PrintColorMessage();
            CustomerValidator validator = new CustomerValidator();
            ValidationResult result = validator.Validate(customer);
            Navigation navigation = new Navigation();


            // Input Customer Name Validation
            if (!result.IsValid)
            {
                colorMessage.Print(ConsoleColor.Red, "\nCustomer not registered! See reason below:");

                //data validation
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine("\n '" + failure.PropertyName + "' written incorrectly . \n Details: " + failure.ErrorMessage);
                }
            }
            else
            {
                using (var context = new ApplicationDbContext())
                {
                    try
                    {
                        context.Customers.Add(customer);

                        try
                        {
                            context.SaveChanges();
                        }
                        catch (SqlException)
                        {
                            colorMessage.Print(ConsoleColor.Red, "Error: CustomerID should not exist in the Customer table");

                        }

                        colorMessage.Print(ConsoleColor.Yellow, "Customer created succesffuly !");
                        
                        navigation.GoToMenu();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }




        // List Customers db manipulations
        public IEnumerable<Customer> ListAll()
        {
            //EF
            using (var context = new ApplicationDbContext())
            {
                var result = context.Customers.ToList();

                return result;
            }
        }




        // Update Customer database manipulations
        public void Update(Customer customer)
        {
            Car car = new Car();
            CustomerValidator validator = new CustomerValidator();
            ValidationResult result = validator.Validate(customer);
            PrintColorMessage colorMessage = new PrintColorMessage();
            
            // Input Customer Name Validation
            if (!result.IsValid)
            {
                colorMessage.Print(ConsoleColor.Red, "\n Customer is not Updated! See reason below:");

                //data validation
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine("\n '" + failure.PropertyName + "' written incorrectly . \n Details: " + failure.ErrorMessage);
                }
            }
            else
            {
                //EF
                using (var context = new ApplicationDbContext())
                {
                    var customerToUpdate =
                        context.Customers.First(x => x.CustomerID == customer.CustomerID);
                    customerToUpdate.Name = customer.Name;
                    customerToUpdate.BirthDate = customer.BirthDate;

                    context.SaveChanges();
                }

            }
        }
    }
}
