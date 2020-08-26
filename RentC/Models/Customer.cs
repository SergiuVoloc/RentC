using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentC.Pages;

namespace RentC.Models
{
    public class Customers
    {
        //private ICollection<ValidationResult> lstvalidationResult;

        public int CustomerID { get; set; }

        [StringLength(3)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public SqlDateTime BirthDate { get; set;}

        public string Location { get; set; }



        /* public  Customers()
         {
             ValidationContext context = new ValidationContext(this, null, null);
             List<ValidationResult> validationResults = new List<ValidationResult>();
             bool valid = Validator.TryValidateObject(this, context, validationResults, true);
             if (!valid)
             {
                 foreach (ValidationResult validationResult in validationResults)
                 {
                     Console.WriteLine("{0}", validationResult.ErrorMessage);
                 }
                 Menu m = new Menu();
                 m.RegisterNewCustomer();
             }
         }*/
    }

}
