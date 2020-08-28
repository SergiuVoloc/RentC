using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentC.Services;

namespace RentC.Models
{
    public class Reservations
    {
        public int ReservationID { get; set; }

        public int CarID { get; set; }

        public int CustomerID { get; set; }

        public short ReservStatsID { get; set; }

        public DateTime StartDate{ get; set; }

        public DateTime EndDate { get; set; }

        public string Location { get; set; }

        public string CouponCode { get; set; }

        public List<Cars> Cars { get; set; }


        // Input Data Validation
        public class ReservationValidator : AbstractValidator<Reservations>
        {
            public ReservationValidator()
            {
                Reservations searchReservation = new Reservations();

                RuleFor(reservation => reservation.CustomerID).NotEmpty(); //NotEqual("{0}",DbConnectionExtension.Exists(CustomerID)???

                RuleFor(reservation => reservation.StartDate).NotEmpty().NotEqual(reservation => reservation.EndDate).LessThan(reservation => reservation.EndDate);
                RuleFor(reservation => reservation.EndDate).NotEmpty();
                RuleFor(reservation => reservation.Location).Equals(searchReservation.Location);

            }
        }
    }
}
