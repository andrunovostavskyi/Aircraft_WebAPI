using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aircraft.Controllers
{
    [ApiController]
    [Route("Flight")]
    public class FlightController : Controller
    {
        public class FlightMainInfo
        {
            public string NameCompany { get; set; } = default!;
            public string NamePlane { get; set; } = default!;
            public ClassTicket ClassTicket { get; set; }
            public int CountSeat { get; set; }
            public Guid tripId { get; set; }
        }

        public readonly AircraftContext _dbContext;
        public List<Flight> flights;
        public FlightController(AircraftContext dbContext)
        {
            _dbContext = dbContext;
            flights = _dbContext.Flights.ToList();
        }

        [HttpGet("Get")]
        public IActionResult Get()
        {
            return Ok(flights);
        }

        [HttpGet("Get{id}")]
        public IActionResult Get(int id)
        {
            Flight flightToAdd = flights.FirstOrDefault(f => f.Id == id)!;
            if(flightToAdd is null)
            {
                return NoContent();
            }
            return Ok(flightToAdd);
        }

        [Authorize(Roles ="Admin")]
        [HttpPost("Post", Name = "Add new flight")]
        public IActionResult Post([FromBody] FlightMainInfo newFlight)
        {
            Flight flightToAdd = new Flight();

            flightToAdd.NamePlane = newFlight.NamePlane;

            flightToAdd.NameCompany = newFlight.NameCompany;

            flightToAdd.CountSeat = newFlight.CountSeat;

            flightToAdd.tripId = newFlight.tripId;

            _dbContext.Add(flightToAdd);
            _dbContext.SaveChanges();
            return Created("Created new flight", flightToAdd);
        }

        [Authorize]
        [HttpPut("Put", Name ="Update by Id")]
        public IActionResult Put(int id, [FromBody] FlightMainInfo flightUpdate)
        {
            Flight flight=flights.FirstOrDefault(f => f.Id == id);
            if (flightUpdate.tripId != Guid.Empty)
            {
                flight.tripId = flightUpdate.tripId;
            }
            flight.CountSeat = flightUpdate.CountSeat;
            flight.NamePlane = flightUpdate.NamePlane;
            flight.NameCompany=flightUpdate.NameCompany;
            _dbContext.SaveChanges();
            return Ok();
        }

        [Authorize]
        [HttpDelete("Delete", Name ="Delete by Id")]
        public IActionResult Delete(int id)
        {
            Flight flightToDelete=flights.FirstOrDefault(f => f.Id == id)!;
            if(flightToDelete == null)
            {
                return NotFound();
            }
            _dbContext.Remove(flightToDelete);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}