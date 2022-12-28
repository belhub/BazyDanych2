using DbApp2.Models;
using DbApp2.Models.Database;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DbApp2.Controllers
{
    public class HomeController : Controller
    {

        private readonly DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }

        public IActionResult ProductsView()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult ReservationsView()
        {
            var reservations = _context.Reservations.ToList();
            return View(reservations);
        }

        public IActionResult SoldView()
        {
            var solds = _context.Solds.ToList();
            return View(solds);
        }

        public IActionResult WorkersView()
        {
            var worksers = _context.Workers.ToList();
            return View(worksers);
        }

        public IActionResult CreateProductView(int id)
        {
            var product = _context.Products
                .Find(id);
            ViewBag.product= product;
            return View(product);
        }

        public IActionResult Index()
        {
            return View();
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