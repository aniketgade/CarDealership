using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.ViewModels
{
    public class ContactViewModel : IValidatableObject
    {
        
        [Required]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required]
        public string Message { get; set; }
        public string VIN { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (String.IsNullOrWhiteSpace(Email) && String.IsNullOrWhiteSpace(Phone))
            {
                errors.Add(new ValidationResult("Please enter either Email or Phone"));
            }

            return errors;
        }
    }
}
