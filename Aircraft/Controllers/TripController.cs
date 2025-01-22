using Aircraft.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Aircraft.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TripController : Controller
    {
        public class TripMainInfo
        {
            public string Departure { get; set; }
            public string Arrival { get; set; }
            public DateTime DataTrip { get; set; }
            public string TimeDeparture { get; set; } // Зміни тип на string
            public string TimeArrival { get; set; }   // Зміни тип на string
        }

        public readonly AircraftContext _dbContext;
        private List<Trip> trips;
        public TripController(AircraftContext dbContext)
        {
            _dbContext = dbContext;
            trips = _dbContext.Trips.ToList();
        }


        [HttpGet("trips", Name = "GetTrip")]
        public IActionResult Get()
        {
            return Ok(trips);
        }

        [HttpGet("trips{id}", Name = "GetTripById")]
        public IActionResult GetById(Guid id)
        {
            Trip findTrip = trips.FirstOrDefault(t => t.Id == id);
            if(findTrip != null)
            {
                return Ok(findTrip);
            }
            return NoContent();
        }

        [Authorize(Roles ="Admin")]
        [HttpPost("Post/trips",Name="AddNewTrip")]
        public IActionResult Post([FromBody] TripMainInfo newTrip)
        {
            Trip tripToAdd = new Trip();
            if (newTrip == null)
            {
                return BadRequest("I need more info for add new trip");
            }
            tripToAdd.Arrival=newTrip.Arrival;
            tripToAdd.Departure=newTrip.Departure;
            tripToAdd.TimeDeparture=TimeSpan.Parse(newTrip.TimeDeparture);
            tripToAdd.TimeArrival= TimeSpan.Parse(newTrip.TimeArrival);
            tripToAdd.DataTrip=newTrip.DataTrip;
            _dbContext.Add(tripToAdd);

            _dbContext.SaveChanges();
            return Created("Create new trip",tripToAdd);
        }

        [Authorize]
        [HttpPut("Put/trips{id}",Name ="UpdateTripById")]
        public IActionResult Put(Guid id, [FromBody] TripMainInfo tripToUpdate)
        {
            Trip findTrip = trips.FirstOrDefault(t => t.Id == id);
            if (findTrip == null)
            {
                return NoContent();
            }
            findTrip.Arrival = tripToUpdate.Arrival;
            findTrip.TimeArrival = TimeSpan.Parse(tripToUpdate.TimeArrival);
            findTrip.Departure= tripToUpdate.Departure;
            findTrip.TimeDeparture= TimeSpan.Parse(tripToUpdate.TimeDeparture);

            _dbContext.SaveChanges();
            return Ok(findTrip);
        }

        [Authorize]
        [HttpDelete("Delete/trips{id}", Name ="DeleteById")]
        public IActionResult Delete(Guid id)
        {
            Trip tripToDelete=trips.FirstOrDefault(t=>t.Id == id);
            if (tripToDelete == null)
            {
                return NotFound();
            }
            _dbContext.Remove(tripToDelete);
            _dbContext.SaveChanges();
            return Ok();
        }
        
    }
}
