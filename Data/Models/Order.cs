using System.Runtime.InteropServices.Marshalling;

namespace ASPMotoDrive.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User Users { get; set; }
        
        public DateTime DateRegister { get;set; }


    }
}
