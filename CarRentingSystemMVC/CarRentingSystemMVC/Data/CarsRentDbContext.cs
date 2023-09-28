using CarRentingSystemMVC.Data.Models;
using CarRentingSystemMVC.Seeding;
using CarRentingSystemMVC.Validations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarRentingSystemMVC.Data
{
    public class CarsRentDbContext : IdentityDbContext
    {
        public CarsRentDbContext(DbContextOptions<CarsRentDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUser>()
                .HasData(DataSeeder.UserSeed());

            builder.Entity<Category>()
                .HasData(DataSeeder.CategoriesSeed().Select(c => c));

            builder.Entity<Car>()
                .HasData(DataSeeder.CarsSeed().Select(c => c));

            builder.Entity<Car>()
                .Property(c => c.Price)
                .HasDefaultValue(DataConstants.PriceDefault);

            base.OnModelCreating(builder);
        }
    }
}