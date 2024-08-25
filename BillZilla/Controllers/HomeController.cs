using BillZilla.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BillZilla.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Bills()
        {
            return View();
        }
        public IActionResult CreateEdit()
        {
            return View();
        }
        public IActionResult BillForm(Bill model)
        {
            return RedirectToAction("Bills");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
