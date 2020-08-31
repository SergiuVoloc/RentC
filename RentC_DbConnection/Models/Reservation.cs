using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentC_DbConnection.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }

        public int CarID { get; set; }

        public string CarPlate { get; set; } //for now... but in future it's better to be in Car Controller 

        public DateTime StartDate{ get; set; }

        public DateTime EndDate { get; set; }

        public string Location { get; set; }

        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

        public short ReservStatsID { get; set; }
        [ForeignKey("ReservStatsID")]
        public ReservationStatuse ReservationStatuse { get; set; }

        public string CouponCode { get; set; }
        [ForeignKey("CouponCode")]
        public Coupon Coupon { get; set; }

        public List<Car> Cars { get; set; }


        // Input Data Validation
        public class ReservationValidator : AbstractValidator<Reservation>
        {
            public ReservationValidator()
            {
                Reservation searchReservation = new Reservation();

                RuleFor(reservation => reservation.CustomerID).NotEmpty(); //NotEqual("{0}",DbConnectionExtension.Exists(CustomerID)???

                RuleFor(reservation => reservation.StartDate).NotEmpty().NotEqual(reservation => reservation.EndDate).LessThan(reservation => reservation.EndDate);
                RuleFor(reservation => reservation.EndDate).NotEmpty();
                RuleFor(reservation => reservation.Location).Equals(searchReservation.Location);

            }
        }
    }
}
