﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using RepoDb;


namespace RentC_WebApplication.Models
{
    public class Customer
    { 

        public int CustomerID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set;}


        // Input Data Validation
        public class CustomerValidator : AbstractValidator<Customer>
        {
            public CustomerValidator()
            {
                RuleFor(customer => customer.CustomerID).NotNull();//NotEqual("{0}",DbConnectionExtension.Exists(CustomerID)                uniq validation???

                RuleFor(customer => customer.Name).MinimumLength(3).NotEmpty(); 

                RuleFor(customer => customer.BirthDate).NotEmpty();


            }
        }
    }

}
