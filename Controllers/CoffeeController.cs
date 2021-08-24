using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoffeeShopApp.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoffeeShopApp.Models;

namespace CoffeeShopApp.Controllers
{
    public class CoffeeController : Controller
    {
        private readonly CoffeeShopContext context;

        public CoffeeController (CoffeeShopContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Coffee";
            return View(await context.Coffees.ToListAsync());
        }
    }
}