using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentC.Models
{
    public class User
    {
        public int UserID { get; set; }

        public string Password { get; set; }

        public byte Enabled { get; set; }

        public int RoleID { get; set; }

    }
}
