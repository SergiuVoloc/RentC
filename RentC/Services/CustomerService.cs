﻿using FluentValidation.Results;
using RentC.Helpers;
using RentC.Models;
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

namespace RentC.Services
{
    public class CustomerService
    {

        // Register Customer db manipulations
        public void Create(Customer customer)
        {
            PrintColorMessage printColorMessage = new PrintColorMessage();
            CustomerValidator validator = new CustomerValidator();
            ValidationResult result = validator.Validate(customer);


            // Input Customer Name Validation
            if (!result.IsValid)
            {
                printColorMessage.Print(ConsoleColor.Red, "\nCustomer not registered! See reason below:");

                //data validation
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine("\n '" + failure.PropertyName + "' written incorrectly . \n Details: " + failure.ErrorMessage);
                }
            }
            else
            {
                using (IDbConnection dbContext = new SqlConnection(ConfigurationManager.ConnectionStrings["RentC"].ConnectionString).EnsureOpen())
                {
                    // database insertion of the new customer 
                    try
                    {

                        var newCustomer = dbContext.Insert(customer);
                        printColorMessage.Print(ConsoleColor.Yellow, "\n Customer inserted succesffuly!");
                    }
                    // Birth Date range validation
                    catch (System.Data.SqlTypes.SqlTypeException)
                    {
                        Console.WriteLine(" \n'Birth Date' should be between:1/1/1753 and 12/31/2002");

                    }
                }
            }
        }




        // List Customers db manipulations
        public IEnumerable<Customer> ListAll()
        {
            using (IDbConnection dbContext = new SqlConnection(ConfigurationManager.ConnectionStrings["RentC"].ConnectionString).EnsureOpen())
            {
                return dbContext.ExecuteQuery<Customer>("select * from [dbo].[Customers];");
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
                using (IDbConnection dbContext = new SqlConnection(ConfigurationManager.ConnectionStrings["RentC"].ConnectionString).EnsureOpen())
                {
                    // database data Update 
                    try
                    {

                        var updateCustomer = new Customer
                        {
                            CustomerID = customer.CustomerID,
                            Name = customer.Name,
                            BirthDate = customer.BirthDate
                        };

                        var affectedRows = dbContext.Update<Customer>(customer);
                        
                    }
                    // Birth Date range validation
                    catch (System.Data.SqlTypes.SqlTypeException)
                    {
                        Console.WriteLine(" \n'Birth Date' should be between:1/1/1753 and 12/31/2020");

                    }
                }
            }
        }
    }
}
