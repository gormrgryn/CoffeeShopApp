using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CoffeeShopApp.Models;
using CoffeeShopApp.Models.ViewModels;
using CoffeeShopApp.Data;

namespace CoffeeShopApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly CoffeeShopContext context;

        public AdminController(CoffeeShopContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Title"] = "Admin Panel";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(
            [Bind("ProductID,Name,Image,DrinkType,Price,Calories")] Product product)
        {
            if (ModelState.IsValid)
            {
                context.Add(product);
                await context.SaveChangesAsync();
                ViewBag.Notification = new NotificationViewModel
                {
                    Type = "success",
                    Title = "Success",
                    Description = $"You have successfully added product {product.Name} to the shop"
                };
            }
            return View();
        }
    }
}