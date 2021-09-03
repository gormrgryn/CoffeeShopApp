using System.Linq;
using System.Collections.Generic;
using CoffeeShopApp.Models;
using CoffeeShopApp.Data;

namespace CoffeeShopApp.Models.ViewModels
{
    public class BasketViewModel
    {
        public List<BasketLine> BasketItems { get; set; }
        public decimal Price { get; set; }
        public decimal Calories { get; set; }
        public int Quantity { get; set; }
    }
}