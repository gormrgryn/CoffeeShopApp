using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeShopApp.Models;
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
            var bList = context.Basket.Where(j => j.BasketLineID != 0);
            List<BasketLine> basketLineList = new List<BasketLine>();
            foreach (var i in bList)
            {
                basketLineList.Add(new BasketLine
                {
                    BasketLineID = i.BasketLineID,
                    Quantity = i.Quantity,
                    Product = context.Products.FirstOrDefault(l => l.ProductID == i.ProductID)
                });
            }
            return View(basketLineList);
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
            return RedirectToAction("Index");
        }
    }
}
