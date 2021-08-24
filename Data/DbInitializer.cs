using System;
using System.Linq;
using CoffeeShopApp.Models;

namespace CoffeeShopApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CoffeeShopContext context)
        {
            context.Database.EnsureCreated();

            if (context.Coffees.Any())
            {
                return; // data has been seeded
            }
            var coffees = new Coffee[]
            {
                new Coffee { Name="Iced Caffè Americano", Image="starbucks-coffee.png", Price=5, Calories=15 },
                new Coffee { Name="Vanilla Sweet Cream Nitro Cold Brew", Image="starbucks-coffee.png", Price=10, Calories=70 },
                new Coffee { Name="Cold Brew Coffee with Milk", Image="starbucks-coffee.png", Price=7, Calories=35 },
                new Coffee { Name="Salted Caramel Cream Cold Brew", Image="starbucks-coffee.png", Price=12, Calories=220 }
            };
            foreach (Coffee coffee in coffees)
            {
                context.Coffees.Add(coffee);
            }
            context.SaveChanges();
        }
    }
}
