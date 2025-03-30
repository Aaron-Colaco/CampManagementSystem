using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WebApplication4Context _context;





        public HomeController(WebApplication4Context context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            var user = _context.Users.Where(a => a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault();

            ViewBag.Year = user.YearLevel;  
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
