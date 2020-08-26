using RentC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentC
{
    class GenericValidator
    {
        public static bool TryValidate(object obj, out ICollection<ValidationResult> results)
        {
            var context = new ValidationContext(obj, serviceProvider: null, items: null);
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(
                obj, context, results,
                validateAllProperties: true
            );
        }

        internal static bool TryValidate(Customers customers, out object lstvalidationResult)
        {
            throw new NotImplementedException();
        }
    }
}
