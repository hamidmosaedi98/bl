using System.Linq;
using BacendBulding.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BacendBulding.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : Controller
    {
        private readonly DBNewbulding _db;

        public AuthenticationController(DBNewbulding db)
        {
            _db = db;
        }
        [HttpPost("login")]
        public IActionResult Login(LoginDTO login)
        {
             var res=_db.Accounts
            .Include(m=>m.Manage)
            .Where(m=>m.Mobile==login.Mobile && m.Password==login.Password)
            .FirstOrDefault();
            if (res!=null)
            {
                res.Password="";
                return Ok(res);
            }
            return Unauthorized(new {Message="نام کاربری یا کلمه عبور صحیح نمی باشد"});
        }

             public class LoginDTO
        {
            public string Mobile { get; set; }
            public string Password { get; set; }

        }
    }
}