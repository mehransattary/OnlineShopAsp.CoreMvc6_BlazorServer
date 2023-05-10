using AspCoreBlazorShop.Models;
using Data.Context;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspCoreBlazorShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext context;
        public HomeController(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("/AbouteUs")]
        public IActionResult AbouteUs()
        {
            return View(context.AbouteUs.FirstOrDefault());
        }
        [Route("/ContactUs")]
        public IActionResult ContactUs()
        {
            return View(context.ContactUs.FirstOrDefault());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}