using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopApp.Controllers
{
    public class CoffeeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Coffee";
            return View();
        }
    }
}