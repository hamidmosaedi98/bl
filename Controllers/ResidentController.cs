using BacendBulding.Database;

using Microsoft.AspNetCore.Mvc;

namespace BacendBulding.Controllers
{
    [ApiController]
    [Route("api/resident")]
    public class ResidentController : Controller
    {
            private readonly DBNewbulding _db;

        public ResidentController(DBNewbulding db)
        {
            _db = db;
        }
        [HttpPost("register")]
        public IActionResult Register(Resident resident)
        {   
                _db.Residents.Add(resident);
                _db.SaveChanges();
                return Ok(new 
                {
                    Message="Ok"
                });
        }
    }
}