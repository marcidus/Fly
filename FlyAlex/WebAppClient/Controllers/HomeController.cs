using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppClient.Models;
using WebAppClient.Services;

namespace WebAppClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFlyServices _flyService;

        public HomeController(ILogger<HomeController> logger, IFlyServices flyServices)
        {
            _logger = logger;
            _flyService = flyServices;
        }

        public async Task<IActionResult> Index()
        {
            var flightList = await _flyService.GetFlights();
            return View(flightList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Flight(int id)
        {
            List<double> results = new List<double>();

            var flightSalePrice = await _flyService.GetPriceFromFlight(id);
            results.Add(flightSalePrice);

            var totalSalePriceOfFlight = await _flyService.GetTotalSalePriceOfFlight(id);
            results.Add(totalSalePriceOfFlight);

            results.Add(id);

            return View(results);
        }

        public IActionResult Booking(int id)
        {
            var booking = new FlightM { FlightId = id };
            return View(booking);
        }

        [HttpPost]
        public async Task<IActionResult> Booking(Booking booking)
        {
            bool test = await _flyService.BookFlight(booking.Passenger.PersonID, booking.Flight.FlightId);
            Console.WriteLine("HomeController : méthode Booking POST " + test);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Details(string destination)
        {
            var averageSalePrice = await _flyService.GetAverageTicketPrice(destination);
            return View(averageSalePrice);
        }

        public async Task<IActionResult> ResumeTicket(string destination)
        {
            var bookedTickets = await _flyService.FinalTicket(destination);
            return View(bookedTickets);
        }

    }
}