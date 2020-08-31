using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentC_DbConnection.Models
{
    public class RolesPermission
    {
        [Key]
        public int RolesPermissionID { get; set; }

        public int RoleID { get; set; }
        [ForeignKey("RoleID")]
        public Role Role { get; set; }

        public int PermissionID { get; set; }
        [ForeignKey("PermissionID")]
        public Permission Permission { get; set; }

    }
}
