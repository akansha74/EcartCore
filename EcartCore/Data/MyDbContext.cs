using EcartCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EcartCore.Data
{
    public class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-JSGHIEB\SQLEXPRESS;Database=AspTest;Trusted_Connection=true;");
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Interest> Interest { get; set; }
        public DbSet<UserInterest> UserInterest { get; set; }
    }
}
