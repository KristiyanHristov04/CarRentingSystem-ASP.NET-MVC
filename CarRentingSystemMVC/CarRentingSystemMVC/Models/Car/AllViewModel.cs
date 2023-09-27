namespace CarRentingSystemMVC.Models.Car
{
    public class AllViewModel
    {
        public List<CarViewModel> Cars { get; set; } = null!;
        public string Category { get; set; } = null!;
        public int MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public string Sort { get; set; } = null!;


        //Pagination logic
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public const int CarsPerPage = 3;

        public int TotalCars { get; set; }
    }
}
