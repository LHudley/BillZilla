using BillZilla.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BillZilla.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly BillZillaDbContext _context;
        public HomeController(ILogger<HomeController> logger, BillZillaDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Bills()
        {
            
            var allBiils = _context.Bills.ToList();
            var totalForBills = allBiils.Sum(x => x.Value);
            ViewBag.Bills = totalForBills;
            return View(allBiils);
        }
        public IActionResult CreateEdit(int? id)
        {
            if(id != null)
            {
                
                var billintheDb = _context.Bills.SingleOrDefault(bill => bill.ID == id);
                return View(billintheDb);

            }
            return View();
        }
        public IActionResult DeleteBill(int id)
        {
            var billintheDb = _context.Bills.SingleOrDefault(bill => bill.ID == id);
            _context.Bills.Remove(billintheDb);
            _context.SaveChanges();
            return RedirectToAction("Bills");
        }
        public IActionResult BillForm(Bill model)
        {
            if(model.ID == 0)
            {
                _context.Bills.Add(model);
            }
            else
            {
                _context.Bills.Update(model);
            }

            //_context.Bills.Add(model);
            _context.SaveChanges();
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
