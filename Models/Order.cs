using System.Runtime.InteropServices.Marshalling;

namespace ASPMotoDrive.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public User Users { get; set; }
        public int MotorcycleId { get; set; }
        public string Description { get; set; }
        public Motorcycle Motorcycles { get; set; }
        public DateTime DateReservation { get; set; } = DateTime.Now;
        public DateTime DateRegister { get;set; } = DateTime.Now;


    }
}
