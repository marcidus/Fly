using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fly;

namespace FlyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly Context _context;

        public FlightsController(Context context)
        {
            _context = context;
        }
     
        // a. Return all flights 
        [HttpGet("GetAvailableFlights")]
        public async Task<ActionResult<List<Flight>>> GetAvailableFlights()
        {
            var flightsAvailableList = await _context.FlightSet.Where(f => f.occupation > 0 && f.Date > DateTime.Now).ToListAsync();
            return flightsAvailableList;
        }
    }

}
