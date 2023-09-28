using CarRentingSystemMVC.Data;
using CarRentingSystemMVC.Data.Models;
using CarRentingSystemMVC.Models.Car;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarRentingSystemMVC.Controllers
{
    [Authorize]
    public class CarsController : Controller
    {
        private readonly CarsRentDbContext _data;

        public CarsController(CarsRentDbContext data)
        {
            this._data = data;
        }

        [AllowAnonymous]
        public IActionResult All(string category, string sort, int minPrice, int? maxPrice, int currentPage)
        {
            ViewBag.CurrentCategory = category;
            ViewBag.AllCategories = GetCategories();
            ViewBag.MaxPrice = maxPrice;
            ViewBag.MinPrice = minPrice;

            AllViewModel allViewModel = new AllViewModel();

            if (currentPage <= 0)
            {
                currentPage = 1;
            }

            allViewModel.CurrentPage = currentPage;
            allViewModel.Category = category;
            allViewModel.MinPrice = minPrice;
            allViewModel.MaxPrice = maxPrice;
            allViewModel.Sort = sort;

            List<CarViewModel> cars = new List<CarViewModel>();

            if (this._data.Categories.Any(c => c.Name == category))
            {
                cars = this._data.Cars
                   .Where(c => c.Category.Name == category)
                   .Select(c => new CarViewModel()
                   {
                       Id = c.Id,
                       Brand = c.Brand,
                       Model = c.Model,
                       ImageUrl = c.ImageUrl,
                       Description = c.Description,
                       Price = c.Price,
                       CategoryName = c.Category.Name,
                       CategoryId = c.CategoryId,
                       UserName = c.User.UserName
                   })
               .ToList();

                if (maxPrice != null && maxPrice > 0)
                {
                    cars = cars.Where(c => c.Price >= minPrice && c.Price <= maxPrice).ToList();
                }
                else
                {
                    cars = cars.Where(c => c.Price >= minPrice).ToList();
                }

                if (sort != null && sort.ToLower() == "ascending")
                {
                    cars = cars.OrderBy(c => c.Price).ToList();
                }
                else if(sort != null && sort.ToLower() == "descending")
                {
                    cars = cars.OrderByDescending(c => c.Price).ToList();
                }

                allViewModel.TotalCars = cars.Count;
                allViewModel.Cars = cars
                    .Skip((allViewModel.CurrentPage - 1) * AllViewModel.CarsPerPage)
                    .Take(AllViewModel.CarsPerPage).ToList();

                return View(allViewModel);
            }

            cars = this._data.Cars
                .Select(c => new CarViewModel()
                {
                    Id = c.Id,
                    Brand = c.Brand,
                    Model = c.Model,
                    ImageUrl = c.ImageUrl,
                    Description = c.Description,
                    Price = c.Price,
                    CategoryName = c.Category.Name,
                    CategoryId = c.CategoryId,
                    UserName = c.User.UserName
                })
            .ToList();


            if (maxPrice != null && maxPrice > 0)
            {
                cars = cars.Where(c => c.Price >= minPrice && c.Price <= maxPrice).ToList();
            }
            else
            {
                cars = cars.Where(c => c.Price >= minPrice).ToList();
            }

            if (sort != null && sort.ToLower() == "ascending")
            {
                cars = cars.OrderBy(c => c.Price).ToList();
            }
            else if (sort != null && sort.ToLower() == "descending")
            {
                cars = cars.OrderByDescending(c => c.Price).ToList();
            }

            allViewModel.TotalCars = cars.Count;
            allViewModel.Cars = cars
                .Skip((allViewModel.CurrentPage - 1) * AllViewModel.CarsPerPage)
                .Take(AllViewModel.CarsPerPage).ToList();

            return View(allViewModel);
        }

        public IActionResult Add()
        {
            CarFormModel carFormModel = new CarFormModel();
            carFormModel.Categories = GetCategories();
            return View(carFormModel);
        }

        [HttpPost]
        public IActionResult Add(CarFormModel carFormModel)
        {
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            carFormModel.Categories = GetCategories();
            ModelState.Remove("Categories");
            bool isCategoryIdValid = this._data.Categories.Any(c => c.Id == carFormModel.CategoryId);
            if (!isCategoryIdValid)
            {
                ModelState.AddModelError("CategoryId", "Invalid category.");
            }

            if (!ModelState.IsValid)
            {
                return View(carFormModel);
            }

            Car car = new Car()
            {
                Brand = carFormModel.Brand,
                Model = carFormModel.Model,
                ImageUrl = carFormModel.ImageUrl,
                Description = carFormModel.Description,
                Price = carFormModel.Price,
                CategoryId = carFormModel.CategoryId,
                UserId = currentUserId
            };

            this._data.Cars.Add(car);
            this._data.SaveChanges();
            return RedirectToAction(nameof(All));
        }

        public IActionResult Edit(int id)
        {
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Car car = this._data.Cars.Find(id)!;

            if (currentUserId != car.UserId)
            {
                return Unauthorized();
            }

            CarFormModel carFormModel = new CarFormModel()
            {
                Brand = car.Brand,
                Model = car.Model,
                ImageUrl = car.ImageUrl,
                Description = car.Description,
                Price = car.Price,
                CategoryId = car.CategoryId,
                Categories = GetCategories()
            };

            return View(carFormModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, CarFormModel carFormModel)
        {
            carFormModel.Categories = GetCategories();
            ModelState.Remove("Categories");
            bool isCategoryIdValid = this._data.Categories.Any(c => c.Id == carFormModel.CategoryId);

            if (!isCategoryIdValid)
            {
                ModelState.AddModelError("CategoryId", "Invalid category.");
            }

            if (!ModelState.IsValid)
            {
                return View(carFormModel);
            }

            Car car = this._data.Cars.Find(id)!;
            car.Brand = carFormModel.Brand;
            car.Model = carFormModel.Model;
            car.ImageUrl = carFormModel.ImageUrl;
            car.Description = carFormModel.Description;
            car.Price = carFormModel.Price;
            car.CategoryId = carFormModel.CategoryId;

            _data.SaveChanges();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Car car = this._data.Cars.Find(id)!;

            if (currentUserId != car.UserId)
            {
                return Unauthorized();
            }

            CarFormModel carFormModel = new CarFormModel()
            {
                Brand = car.Brand,
                Model = car.Model,
                ImageUrl = car.ImageUrl,
                Description = car.Description,
                Price = car.Price,
                CategoryId = car.CategoryId,
                Categories = GetCategories()
            };

            return View(carFormModel);
        }

        [HttpPost]
        public IActionResult Delete(int id, CarFormModel carFormModel)
        {
            Car car = this._data.Cars.Find(id)!;
            this._data.Cars.Remove(car);
            this._data.SaveChanges();
            return RedirectToAction(nameof(All));
        }

        private List<CategoryViewModel> GetCategories()
        {
            return this._data.Categories.Select(c => new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToList();
        }
    }
}
