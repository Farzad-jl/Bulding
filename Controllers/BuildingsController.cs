using System.Collections.Generic;
using System.Linq;
using BacendBulding.Database;
using BacendBulding.Database.Models;
using Microsoft.AspNetCore.Authorization;
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
        //[Authorize]
        public IActionResult create (Building building)
        {
            // var mobile=User.Claims.Where(m=>m.Type=="id").FirstOrDefault().Value;
            // var account=_db.Accounts
            // .Include(m=>m.Manage)
            // .Where(m=>m.Mobile==mobile)
            // .FirstOrDefault();
            // if (account==null || account.Manage==null)
            // {
            //     return Unauthorized();
            // }

            // var createe = new Building
            // {
            //     Manage=account.Manage,
            //     AccountMobile=mobile,
            //     BuildingName=building.BuildingName,
            //     FloorNumber=building.FloorNumber,
            //     UnitNumber=building.UnitNumber,
            //     Address=building.Address
            // };

            
            _db.Buildings.Add(building);
            _db.SaveChanges();
            return Ok();


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



        [HttpGet("getlist/{id}")]
        public ActionResult<Building> GetList(string id)
        {
            return _db.Buildings
            .Include(m=>m.Manage)
            .Where(m=>m.AccountMobile == id)
            .FirstOrDefault();
           
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