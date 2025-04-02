using System.Runtime.InteropServices.Marshalling;

namespace ASPMotoDrive.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public User Users { get; set; }
        public int MotorcycleId { get; set; }
        public Motorcycle Motorcycles { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        
        public DateTime DateRegister { get;set; }


    }
}
