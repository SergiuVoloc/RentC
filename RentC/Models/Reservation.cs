using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
