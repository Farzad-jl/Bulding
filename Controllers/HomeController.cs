using System;
using System.Collections.Generic;
using System.Linq;
using BacendBulding.Database;
using BacendBulding.Database.Models;
using BacendBuldinghamid.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BacendBuldinghamid.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : Controller
    {
        private readonly DBNewbulding _db;

        public HomeController(DBNewbulding db)
        {
            _db = db;
        }

        [HttpGet("list")]
       public ActionResult<List<BuildingDTO>> List()
        {
            var Subscribes = new List<int>();
            if (User.Identity.IsAuthenticated)
            {
            var mobile=User.Claims.Where(c=>c.Type == "id").FirstOrDefault().Value;
             Subscribes=
             _db.Subscribes
             .Include(c=>c.Building)
             .Include(c=>c.Resident)
             .Where(s=>s.Resident.AccountMobile == mobile)
             .Select(c=>c.Building.Id)
             .ToList();  
            }
            return _db
            .Buildings
            .OrderByDescending(c=>c.Id)
            .Select(c=> new BuildingDTO
            {
                BuildingName=c.BuildingName,
                Address=c.Address,
                UnitNumber=c.UnitNumber,
                FloorNumber=c.FloorNumber,
                CanSubscribe=!Subscribes.Contains(c.Id),
                Id=c.Id
            })
            .ToList();
        }



        [HttpPost("subscribe/{id}")]
        [Authorize]
        public ActionResult Subscribe (int id)
        {
            var building =_db.Buildings.FirstOrDefault(m=>m.Id == id);
            if (building==null)
            {
                return NotFound();
            }
            var mobile=User.Claims.Where(b=>b.Type == "id").FirstOrDefault().Value;
            var account=_db.Accounts
                .Include(m=>m.Resident)
                .Where(a=>a.Mobile == mobile)
                .FirstOrDefault();
            if (account==null || account.Resident==null)
            {
                return Unauthorized();
            }
            var subscribe=new Subscribe
            {
                Building=building,
                Resident=account.Resident,
                IsActive=true,
                SubscribeTime=DateTime.Now

            };
            _db.Subscribes.Add(subscribe);
            _db.SaveChanges();
            return Ok();
        }
    }
} 