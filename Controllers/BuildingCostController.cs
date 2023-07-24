using System.Collections.Generic;
using System.Linq;
using BacendBulding.Database;
using BacendBulding.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BacendBulding.Controllers
{
    [ApiController]
    [Route("api/buildingCost")]
    public class BuildingCostController : Controller
    {
        private readonly DBNewbulding _db;

        public BuildingCostController(DBNewbulding db)
        {
            _db = db;
        }

        [HttpPost("create")]
        public IActionResult create(BuildingCost cost)
        {
            try
            {
                _db.BuildingCosts.Add(cost);
                _db.SaveChanges();
                return Ok(new 
                {
                    Message="Ok"
                });
            }
            catch (System.Exception)
            {
                
                throw;
            }

        }
        [HttpPost("list")]
        public ActionResult<IEnumerable<BuildingCost>> List(ListRequest request)
        {
            var pageSize=5;
            var page=0;
            if (request!=null)
            {
                page=request.Page;
            }
            return _db
                    .BuildingCosts
                    .Skip(request.Page*pageSize)
                    .Take(5)
                    .ToList();


        }
         [HttpGet("get/{id}")]
        public ActionResult<BuildingCost> Get(int id)
        {
            return _db.BuildingCosts.Find(id);
            
           
        }
        [HttpPost("edit/{id}")]
        public IActionResult Edit(string id, BuildingCost cost)
        {
       
                var c=_db.BuildingCosts.Find(id);
                if (c!=null)
                {
                    c.Title=cost.Title;
                    c.Date=cost.Date;
                    c.Amount=cost.Amount;
                    c.Description=cost.Description;
                _db.SaveChanges();
                return Ok(new 
                {
                    Message="Ok"
                });
                }
                return NotFound();

        }


    }
}