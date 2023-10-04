using CarRentingSystemMVC.Validations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentingSystemMVC.Data.Models
{
    public class Rent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [CreditCard]
        public string CreditCardNumber { get; set; } = null!;

        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string CreditCardCVV { get; set; } = null!;

        [Required]
        public string ExpirationDate { get; set; } = null!;

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
        public int Days { get; set; }

        [Required]
        public double TotalPrice { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public IdentityUser User { get; set; } = null!;
    }
}
