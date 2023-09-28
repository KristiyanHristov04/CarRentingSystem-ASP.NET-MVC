using CarRentingSystemMVC.Validations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentingSystemMVC.Data.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.BrandMaxLength)]
        public string Brand { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.ModelMaxLength)]
        public string Model { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.DesriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public double Price { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public IdentityUser User { get; set; } = null!;
    }
}
