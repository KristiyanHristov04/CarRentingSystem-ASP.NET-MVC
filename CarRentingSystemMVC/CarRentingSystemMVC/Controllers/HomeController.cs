using CarRentingSystemMVC.Data;
using CarRentingSystemMVC.Models;
using CarRentingSystemMVC.Models.Car;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CarRentingSystemMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly CarsRentDbContext _data;

        public HomeController(CarsRentDbContext data)
        {
            this._data = data;
        }

        public IActionResult Index()
        {
            ViewBag.TotalCars = this._data.Cars.Count();
            List<CarViewModel> cars = this._data.Cars.Select(c => new CarViewModel()
            {
                Id = c.Id,
                Brand = c.Brand,
                Model = c.Model,
                ImageUrl = c.ImageUrl,
                Description = c.Description,
                Price = c.Price,
                CategoryName = c.Category.Name,
                CategoryId = c.Category.Id
            })
            .OrderByDescending(c => c.Id)
            .Take(3)
            .ToList();
            
            return View(cars);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}