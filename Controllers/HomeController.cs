using Microsoft.AspNetCore.Mvc;
using Proyecto_Hospital.Models;
using Proyecto_Hospital.Services;
using System.Diagnostics;

namespace Proyecto_Hospital.Controllers
{
    public class HomeController : Controller
    {
        private readonly NewsService newsService;


        private readonly ILogger<HomeController> _logger ;

        public HomeController(ILogger<HomeController> logger, NewsService newsService)
        {
            _logger = logger;
            this.newsService = newsService;
        }

        public IActionResult NewsV()
        {
            var topNews = newsService.GetTopNews("Health", 10);
            return View(topNews);
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {


            return View();


        }  
        public IActionResult Gallery()
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