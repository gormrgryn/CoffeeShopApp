using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using CoffeeShopApp.Models;

namespace CoffeeShopApp.Data
{
    public class CoffeeShopContext : DbContext
    {
        public CoffeeShopContext(DbContextOptions<CoffeeShopContext> options)
            : base(options) {}

        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<Tea> Teas { get; set; }

        // protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        //     modelBuilder.Entity<CoffeeShopContext>().HasNoKey();
    }
}