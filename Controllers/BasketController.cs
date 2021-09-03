using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeShopApp.Models;
using CoffeeShopApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using CoffeeShopApp.Data;

namespace CoffeeShopApp.Controllers
{
    public class BasketController : Controller
    {
        private readonly CoffeeShopContext context;

        public BasketController(CoffeeShopContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var basketProductsList = context.Basket.Where(j => j.BasketLineID != 0);
            List<BasketLine> basketLineList = new List<BasketLine>();
            decimal price = 0;
            decimal calories = 0;
            int quantity = 0;
            foreach (var i in basketProductsList)
            {
                var product = context.Products.FirstOrDefault(l => l.ProductID == i.ProductID);
                basketLineList.Add(new BasketLine
                {
                    BasketLineID = i.BasketLineID,
                    Quantity = i.Quantity,
                    Product = product
                });
                price += product.Price;
                calories += product.Calories;
                quantity += i.Quantity;
            }
            return View(new BasketViewModel
            {
                BasketItems = basketLineList,
                Price = price,
                Calories = calories,
                Quantity = quantity
            });
        }
        [HttpPost]
        public async Task<IActionResult> AddToBasket(int productId)
        {
            Product product = context.Products
                .FirstOrDefault(p => productId == p.ProductID);
            if (product != null)
            {
                BasketItem item = context.Basket.FirstOrDefault(i => i.ProductID == productId);
                if (item != null) item.Quantity++;
                else {
                    BasketItem bitem = new BasketItem
                    {
                        ProductID = productId,
                        Quantity = 1
                    };
                    context.Basket.Add(bitem);
                }
                await context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Coffee");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var products = await context.Basket.FindAsync(id);
            context.Basket.Remove(products);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
