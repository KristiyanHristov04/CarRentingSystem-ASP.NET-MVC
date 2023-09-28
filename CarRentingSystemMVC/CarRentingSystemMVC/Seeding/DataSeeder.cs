using CarRentingSystemMVC.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace CarRentingSystemMVC.Seeding
{
    public static class DataSeeder
    {
        static string userGeneratedId = Guid.NewGuid().ToString();
        public static IdentityUser UserSeed()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            IdentityUser user = new IdentityUser()
            {
                Id = userGeneratedId,
                UserName = "user",
                NormalizedUserName = "USER",
                Email = "user@abv.bg",
                NormalizedEmail = "USER@ABV.BG",
                EmailConfirmed = true
            };

            user.PasswordHash = hasher.HashPassword(user, "123456zZ!");

            return user;
        }

        public static List<Category> CategoriesSeed()
        {
            Category category01 = new Category()
            {
                Id = 1,
                Name = "Mini"
            };

            Category category02 = new Category()
            {
                Id = 2,
                Name = "SUV"
            };

            Category category03 = new Category()
            {
                Id = 3,
                Name = "Sport"
            };

            Category category04 = new Category()
            {
                Id = 4,
                Name = "Compact"
            };

            Category category05 = new Category()
            {
                Id = 5,
                Name = "Sedan"
            };

            return new List<Category>() { category01, category02, category03, category04, category05 };
        }

        public static List<Car> CarsSeed()
        {
            Car car01 = new Car()
            {
                Id = 1,
                Brand = "BMW",
                Model = "X5",
                ImageUrl = "https://cdni.autocarindia.com/Utils/ImageResizer.ashx?n=https://cdni.autocarindia.com/ExtraImages/20230714060819_BMW_X5_facelift.jpg",
                Description = "The best SUV in the entire world! Rent Now!",
                Price = 55.31,
                CategoryId = 2,
                UserId = userGeneratedId
            };

            Car car02 = new Car()
            {
                Id = 2,
                Brand = "Audi",
                Model = "A7",
                ImageUrl = "https://media.audifrance.fr/wp-content/uploads/2020/08/929104-2000x1414.jpg",
                Description = "Audi A7 is a new generation vehicle! Rent Now!",
                Price = 165.29,
                CategoryId = 5,
                UserId = userGeneratedId
            };

            return new List<Car>() { car01, car02 };
        }
    }
}
