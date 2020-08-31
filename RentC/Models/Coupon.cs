﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentC_ConsoleApplication.Models
{
    public class Coupon
    {
        [Key]
        public string CouponCode { get; set; }

        public string Description { get; set; }

        public decimal Discount { get; set; }
    }
}
