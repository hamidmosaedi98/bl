using System.Collections.Generic;
using System.Linq;
using BacendBulding.Database;
using BacendBulding.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace BacendBulding.Controllers
{
    [ApiController]
    [Route("api/complaint")]
    public class ComplaintController : Controller
    {
        private readonly DBNewbulding _db;

        public ComplaintController(DBNewbulding db)
        {
            _db = db;
        }

        [HttpPost("create")]
        public IActionResult Create(Complaint complaint)
        {   
                _db.Complaints.Add(complaint);
                _db.SaveChanges();
                return Ok(new 
                {
                    Message="Ok"
                });
        }

        
        [HttpPost("list")]
        public ActionResult<IEnumerable<Complaint>> List(ListRequest request)
        {
            var pageSize=5;
            var page=0;
            if (request!=null)
            {
                page=request.Page;
            }
            return _db
                    .Complaints
                    .Skip(request.Page*pageSize)
                    .Take(5)
                    .ToList();
        }
    }
}