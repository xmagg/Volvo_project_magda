using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsPlatform2.Models;
using NewsPlatform2.Models.Entities;
using System.Diagnostics;

namespace NewsPlatform2.Controllers
{
    public class HomeController : Controller
    {
        private readonly NewsDbContext _dbContext;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public List<News> List()
        {
            var news = _dbContext.Newss.ToList();
            return news;
        }
        public IActionResult About()
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