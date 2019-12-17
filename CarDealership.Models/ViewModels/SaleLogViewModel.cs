using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarDealership.Models.ViewModels
{
    public class SaleLogViewModel : IValidatableObject
    {
        [Display(Name = "Name")]
        [Required]
        public string BuyerName { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required]
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip")]
        public string ZipCode { get; set; }
        [Required]
        public decimal PurchasePrice { get; set; }
        [Required]
        public string PurchaseType { get; set; }
        public int VehicleId { get; set; }
        public string Phone { get; set; }
        public string SalesUserId { get; set; }
        public decimal SalePrice { get; set; }
        public decimal MSRP { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (String.IsNullOrWhiteSpace(Email) && String.IsNullOrWhiteSpace(Phone))
            {
                errors.Add(new ValidationResult("Please enter either Email or Phone"));
            }


            if (Decimal.ToDouble(PurchasePrice) < 0.95*(Decimal.ToDouble(SalePrice)))
            {
                errors.Add(new ValidationResult("The purchase price cannot be less than 95% of the sales price"));
            }


            if (PurchasePrice > MSRP)
            {
                errors.Add(new ValidationResult("The purchase price cannot exceed the MSRP"));
            }

            return errors;
        }
    }
}
