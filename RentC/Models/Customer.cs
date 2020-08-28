using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentC.Pages;
using FluentValidation;
using RepoDb;


namespace RentC.Models
{
    public class Customers
    {
        //private ICollection<ValidationResult> lstvalidationResult;

        public int CustomerID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set;}
        public string Location { get; set; }


        // Input Data Validation
        public class CustomerValidator : AbstractValidator<Customers>
        {
            public CustomerValidator()
            {
                RuleFor(customer => customer.Name).MinimumLength(3).NotEmpty(); //NotEqual("{0}",DbConnectionExtension.Exists(CustomerID)???

            }
        }
    }

}
