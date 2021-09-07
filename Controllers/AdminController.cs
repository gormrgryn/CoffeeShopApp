using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CoffeeShopApp.Models;
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
            }
            return View();
        }
    }
}