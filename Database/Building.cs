using System.Collections.Generic;

namespace BacendBulding.Database
{
    public class Building
    {
        public int Id { get; set; }
        public string AccountMobile { get; set; }
        public string BuildingName { get; set; }
        public string  Address { get; set; }
        public int UnitNumber { get; set; }
        public int FloorNumber { get; set; }
        public Manage Manage { get; set; }
        public List<Resident> Resident { get; set; }
    }
}

