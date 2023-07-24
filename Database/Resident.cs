using System.Collections.Generic;

namespace BacendBulding.Database
{
    public class Resident
    {
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public int FloorNumber { get; set; }
        public int UnitNumber { get; set; }
        public Account Account { get; set; }
        //کلید
        public string AccountMobile { get; set; }
        
        public ICollection<Complaint> complaints { get; set; }

        public Building Building { get; set; }
        public int? BuildingId { get; set; }

    }

}