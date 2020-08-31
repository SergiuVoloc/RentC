
using FluentValidation;

namespace RentC_DbConnection.Models
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
