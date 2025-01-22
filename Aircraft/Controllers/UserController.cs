using Microsoft.AspNetCore.Mvc;

namespace Aircraft.Controllers
{
    public class UserController : Controller
    {
        private readonly AircraftContext _dbcontext;
        private List<AppUser> users;
        public UserController(AircraftContext dbcontext)
        {
            _dbcontext = dbcontext;
            users= dbcontext.Users.ToList();
        }

        [HttpGet("/Get")]
        public IActionResult Get()
        {
            return Ok(users);
        }

        [HttpGet("/Get/id")]
        public IActionResult Get(string id) 
        {
            AppUser userById = users.FirstOrDefault(u => u.Id == id);
            if (userById == null)
            {
                return NotFound();
            }
            return Ok(userById);
        }
    }
}
