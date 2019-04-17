using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DO = OutingAdvisorV2DataObjects;
using HttpClients = OutingAdvisorV2.HttpClientServices.LocationServices;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OutingAdvisor2.Controllers
{
    public class LocationController : Controller
    {
        private readonly HttpClients.LocationService _locationService;

        public LocationController(HttpClients.LocationService locationService)
        {
            _locationService = locationService;
        }
        // GET: /<controller>/
        public IActionResult Index(int? identity)
        {
            var _task = _locationService.GetAll();
            _task.Wait();

            List<DO.Location> tes =_task.Result;
            
            return View();
        }
    }
}
