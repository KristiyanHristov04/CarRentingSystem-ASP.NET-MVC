using CarRentingSystemMVC.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CarRentingSystemMVC.Validations;

namespace CarRentingSystemMVC.Models.Car
{
    public class CarFormModel
    {
        [Required]
        [StringLength(DataConstants.BrandMaxLength, MinimumLength = DataConstants.BrandMinLength)]
        public string Brand { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.ModelMaxLength, MinimumLength = DataConstants.ModelMinLength)]
        public string Model { get; set; } = null!;

        [Required]
        [Url(ErrorMessage = "The provided URL is not valid.")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.DesriptionMaxLength, MinimumLength = DataConstants.DesriptionMinLength)]
        public string Description { get; set; } = null!;


        [Required]
        [Range(DataConstants.PriceMin, DataConstants.PriceMax)]
        public double Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public List<CategoryViewModel> Categories { get; set; } = null!;
    }
}
