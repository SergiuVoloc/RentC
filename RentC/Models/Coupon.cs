using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentC.Models
{
    public class Coupons
    {
        public int CouponCode { get; set; }

        public string Description { get; set; }

        public decimal Discount { get; set; }
    }
}
