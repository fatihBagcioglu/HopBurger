using HopBurger.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HopBurger.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()

        {
            var vm = new HomeViewModel()
            {
                Categories = _db.Categories.OrderBy(x => x.Name).ToList(),
                Items = _db.Items.OrderBy(x => x.Name).ToList(),
            };

            return View(vm);
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