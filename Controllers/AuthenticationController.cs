using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using BacendBulding.Database;
using BacendBuldinghamid.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BacendBulding.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : Controller
    {
        private readonly DBNewbulding _db;
        private readonly AppSettings _appSettings;
        public AuthenticationController(DBNewbulding db,IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _db = db;
        }
        [HttpPost("login")]
        public IActionResult Login(LoginDTO login)
        {
             var res=_db.Accounts
            .Include(m=>m.Manage)
            .Include(r=>r.Resident)
            .Where(m=>m.Mobile==login.Mobile && m.Password==login.Password)
            .FirstOrDefault();
            if (res!=null)
            {
                res.Password="";
                //sakhet token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("id", res.Mobile) }),
                    Expires = DateTime.Now.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString=tokenHandler.WriteToken(token);
                //payan sakht token
                return Ok(new {Account=res,Token=tokenString});
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