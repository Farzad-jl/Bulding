using System;
using BacendBulding.Database;

namespace BacendBuldinghamid.Database
{
    public class Subscribe
    {
        public int Id { get; set; }
        public Building Building { get; set; }
        public Resident Resident { get; set; }
        public DateTime SubscribeTime { get; set; }
        public bool IsActive { get; set; }
    }
}