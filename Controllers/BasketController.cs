using System.Linq;
using CoffeeShopApp.Models;
using Microsoft.AspNetCore.Mvc;
using CoffeeShopApp.Data;
using CoffeeShopApp.Infrastructure;

namespace CoffeeShopApp.Controllers
{
    public class BasketController : Controller
    {
        private readonly CoffeeShopContext context;

        public BasketController (CoffeeShopContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddToBasket(int productId)
        {
            Product product = context.Products
                .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                Basket basket = GetBasket();
                basket.AddItem(product, 1);
                SaveBasket(basket);
            }
            return RedirectToAction("Index");
        }
        private Basket GetBasket()
        {
            return HttpContext.Session.GetJson("Basket") ?? new Basket();
        }
        private void SaveBasket(Basket basket)
        {
            HttpContext.Session.SetJson("Basket", basket);
        }
    }
}
