using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OutingAdvisorV2.Models;
using HttpClients = OutingAdvisorV2.HttpClientServices.LocationServices;

namespace OutingAdvisorV2.Controllers
{
    public class HomeController : Controller
    {

        public HomeController(HttpClients.LocationService locationService)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Welcome to a unique travel experience:";

            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
