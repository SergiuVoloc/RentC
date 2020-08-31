using RentC_ConsoleApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentC_ConsoleApplication.ViewModels
{
    public class AvaiableCarViewModel
    {
        [DisplayName("Car Plate")]
        public string CarPlate { get; set; }

        [DisplayName("Car Model")]
        public string CarModel { get; set; }

        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

        public string Location { get; set; }

        public IEnumerable<Car> Cars { get; set; }
    }
}
