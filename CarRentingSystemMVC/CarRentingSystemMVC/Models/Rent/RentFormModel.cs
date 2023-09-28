using CarRentingSystemMVC.Validations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarRentingSystemMVC.Models.Rent
{
    public class RentFormModel
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(DataConstants.CreditCardRegularExpression)]
        public string CreditCardNumber { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.CreditCardCVVMinLength, MinimumLength = DataConstants.CreditCardCVVMaxLength)]
        [RegularExpression(DataConstants.CreditCardCVVRegularExpression)]
        public string CreditCardCVV { get; set; } = null!;

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.BrandMaxLength)]
        public string CarBrand { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.ModelMaxLength)]
        public string CarModel { get; set; } = null!;

        [Required]
        [Range(DataConstants.DaysMinLength, DataConstants.DaysMaxLength)]
        public int Days { get; set; }

        [Required]
        public double TotalPrice { get; set; }

        public double PricePerDay { get; set; }
    }
}
