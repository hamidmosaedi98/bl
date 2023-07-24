using System.Collections.Generic;
using System.Linq;
using BacendBulding.Database;
using BacendBulding.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BacendBulding.Controllers
{
    [ApiController]
    [Route("api/building")]
    public class BuildingsController : Controller
    {
        private readonly DBNewbulding _db;

        public BuildingsController(DBNewbulding db)
        {
            _db = db;
        }

        [HttpPost("create")]
        public IActionResult create(Building building)
        {
            try
            {
                _db.Buildings.Add(building);
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
        public ActionResult<IEnumerable<BuildingDTO>> List()
        {
            return _db
            .Buildings
            .Select(b=> new BuildingDTO
            {
                AccountMobile=b.AccountMobile,
                BuildingName=b.BuildingName,
                Address=b.Address,
                UnitNumber=b.UnitNumber,
                FloorNumber=b.FloorNumber

            }).ToList();
        }
        [HttpGet("get/{id}")]
        public ActionResult<Building> Get(string id)
        {
            return _db.Buildings
            .Include(m=>m.Manage)
            .Where(m=>m.AccountMobile == id)
            .FirstOrDefault();
           
        }
        [HttpPost("edit/{id}")]
        public IActionResult Edit(string id, Building building)
        {
       
                var b =_db.Buildings.Find(id);
                if (b!=null)
                {
                    
                b.BuildingName=building.BuildingName;
                b.Address=building.Address;
                b.FloorNumber=building.FloorNumber;
                b.UnitNumber=building.UnitNumber;
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