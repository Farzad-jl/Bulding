using BacendBulding.Database;
using Microsoft.AspNetCore.Mvc;

namespace BacendBuldinghamid.Controllers
{
    public class CorseController:Controller
    {
        private readonly DBNewbulding _db;

        public CorseController(DBNewbulding db)
        {
            _db = db;
        }
        
    }
}