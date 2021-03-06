using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using CoffeeShopApp.Models;

namespace CoffeeShopApp.Data
{
    public class CoffeeShopContext : DbContext
    {
        public CoffeeShopContext(DbContextOptions<CoffeeShopContext> options)
            : base(options) {}

        public DbSet<Product> Products { get; set; }
        public DbSet<BasketItem> Basket { get; set; }
    }
}
