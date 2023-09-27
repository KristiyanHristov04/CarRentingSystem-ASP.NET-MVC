using System.ComponentModel.DataAnnotations;

namespace CarRentingSystemMVC.Models.Car
{
    public class ContactFormModel
    {
        [Required]
        public string Subject { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = null!;

        [Required]
        public string Message { get; set; } = null!;
    }
}
