using FlightSearchEngine.Interfaces;
using FlightSearchEngine.Models;
using Microsoft.AspNetCore.Mvc;
using NLog.Filters;
using System.Diagnostics;

namespace FlightSearchEngine.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpServices _httpServices;

        public HomeController(ILogger<HomeController> logger, IHttpServices httpServices)
        {
            _logger = logger;
            _httpServices = httpServices;
        }

        public  IActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> GetFlights( string filter)
        {
            _logger.LogInformation("Home controller with filter {@filter} has been called.",filter);

            var cancelationToken = new CancellationToken();

            var data = await _httpServices.GetDataAsync(filter);

            return View(viewName:"_flightsTable",model:data);
        }
        public IActionResult AboutApplication()
        {
            _logger.LogInformation("AboutApplication controller with filter has been called.");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}