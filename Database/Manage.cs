namespace BacendBulding.Database
{
    public class Manage:ILoginCapable
    {
        public string Fullname { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public Account Account { get; set; }
        public string AccountMobile { get; set; }
        public Building Building { get; set; }


    }
}