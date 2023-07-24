using System;
using BacendBulding.Database;
using Microsoft.AspNetCore.Mvc;

namespace BacendBulding.Controllers
{
    [ApiController]
    [Route("api/manages")]
    public class ManagesController : Controller
    {
        private readonly DBNewbulding _db;

        public ManagesController(DBNewbulding db)
        {
            _db = db;
        }

        [HttpPost("register")]
        public IActionResult Rgister(Manage manage)
        {
            try
            {
                _db.Manages.Add(manage);
                _db.SaveChanges();
                return Ok(new 
                {
                    Message="Ok"
                });
            }
            catch(Exception exception)
            {
                var message=exception.Message;
                if(exception.InnerException.Message.Contains("Cannot insert duplicate key in object 'dbo.Accounts'"))
                {
                    message="شماره همراه وارد شده قبلا ثبت شده است";
                }
                return BadRequest(new 
                {
                    Message=message
                });
            }
        }
    }
}