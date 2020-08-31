using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentC_WebApplication.Models
{
    public class ReservationStatuse
    {
        [Key]
        public short ReservStatsID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

    }
}
