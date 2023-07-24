using System;

namespace BacendBulding.Database
{
    public class Complaint
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Time { get; set; }
        public string Body { get; set; }
        
        public Resident Resident { get; set; }
        public string AccountMobile { get; set; }

    }
}