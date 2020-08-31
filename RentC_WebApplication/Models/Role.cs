using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentC_WebApplication.Models
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

    }
}
