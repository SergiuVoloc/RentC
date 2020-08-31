using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RentC_ConsoleApplication.Models
{
    public class Car
    {
        public int CarID { get; set; }

        public string Plate { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public decimal PricePerDay { get; set; }

        public string Location { get; set; }



        // Input Data Validation
        public class CarValidator : AbstractValidator<Car>
        {
            public CarValidator()
            {
                RuleFor(car => car.Plate).NotEmpty(); 

            }
        }
    }
}
