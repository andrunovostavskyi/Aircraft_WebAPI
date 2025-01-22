using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aircraft.Controllers
{
    [ApiController]
    [Route("Seat" )]
    public class SeatController : Controller
    {
        public class SeatMainInfo
        {
            public int Number { get; set; }

            public double Price { get; set; }

            public ClassTicket ClassSeat { get; set; }

            public int flightId { get; set; }
        }

        public readonly AircraftContext _dbContext;
        public List<Seat> seats;
        public SeatController(AircraftContext dbContext)
        {
            _dbContext = dbContext;
            seats = _dbContext.Seats.ToList();
        }

        [HttpGet("Get")]
        public IActionResult Get()
        {
            return Ok(seats);
        }

        [HttpGet("Get{id}")]
        public IActionResult Get(int id)
        {
            Seat seat = seats.FirstOrDefault(s=>s.Id == id);
            return Ok(seat);
        }

        [Authorize(Roles ="Admin")]
        [HttpPost("Post")]
        public IActionResult Post([FromBody] SeatMainInfo newSeat)
        {
            Seat seatToAdd = new Seat();
            seatToAdd.Number = newSeat.Number;
            seatToAdd.Price = newSeat.Price;
            seatToAdd.ClassSeat = newSeat.ClassSeat;
            seatToAdd.flightId = newSeat.flightId;

            _dbContext.Seats.Add(seatToAdd);
            _dbContext.SaveChanges();
            return Created("Succes", seatToAdd);
        }

        [Authorize]
        [HttpPut("Put{id}")]
        public IActionResult Put(int id,[FromBody] SeatMainInfo seatForUpdate)
        {
            Seat newSeat = seats.FirstOrDefault(s=>s.Id==id);
            
            newSeat.Number=seatForUpdate.Number;
            newSeat.Price=seatForUpdate.Price;
            newSeat.ClassSeat=seatForUpdate.ClassSeat;
            if (seatForUpdate.flightId!= 0)
            {
                newSeat.flightId = seatForUpdate.flightId;
            }
            _dbContext.SaveChanges();
            return Created("Succes", newSeat);
        }

        [Authorize]
        [HttpDelete("Delete{id}")]
        public IActionResult Delete(int id)
        {
            Seat seatToDelete=seats.FirstOrDefault(s=>s.Id == id);
            if (seatToDelete == null)
            {
                return NotFound();
            }
            _dbContext.Remove(seatToDelete);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
