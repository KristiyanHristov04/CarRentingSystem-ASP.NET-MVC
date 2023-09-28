using CarRentingSystemMVC.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarRentingSystemMVC.Models.Car
{
    public class CarViewModel
    {
        public int Id { get; set; }

        public string Brand { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Description { get; set; } = null!;

        public double Price { get; set; }

        public string CategoryName { get; set; } = null!;

        public int CategoryId { get; set; }

        public string UserName { get; set; } = null!;

    }
}
