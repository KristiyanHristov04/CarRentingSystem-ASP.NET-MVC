using CarRentingSystemMVC.Validations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarRentingSystemMVC.Models.Rent
{
    public class RentFormModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Card number field is required.")]
        [RegularExpression(DataConstants.CreditCardRegularExpression, ErrorMessage = "Card number must follow the pattern '0000 0000 0000'")]
        public string CreditCardNumber { get; set; } = null!;

        [Required(ErrorMessage = "Card number's CVV/CVC field is required.")]
        [StringLength(DataConstants.CreditCardCVVMinLength, MinimumLength = DataConstants.CreditCardCVVMaxLength)]
        [RegularExpression(DataConstants.CreditCardCVVRegularExpression, ErrorMessage = "Card number's CVV/CVC must be three digits")]
        public string CreditCardCVV { get; set; } = null!;

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required(ErrorMessage = "First name field is required.")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last name field is required.")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Address field is required.")]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.BrandMaxLength)]
        public string CarBrand { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.ModelMaxLength)]
        public string CarModel { get; set; } = null!;

        [Required(ErrorMessage = "Days field is required.")]
        [Range(DataConstants.DaysMinLength, DataConstants.DaysMaxLength, ErrorMessage = "Choose days from 1 to 365.")]
        public int Days { get; set; } = 1;

        [Required]
        public double TotalPrice { get; set; }

        public double PricePerDay { get; set; }
    }
}
