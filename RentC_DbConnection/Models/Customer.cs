using System;
using FluentValidation;

namespace RentC_DbConnection.Models
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
