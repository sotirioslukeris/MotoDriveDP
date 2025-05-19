using ASPMotoDrive.Models;

namespace ASPMotoDrive.Data.Models
{
    public class CartItem
    {
        public int Id { get; set; } 
        public int MotorcycleId { get; set; }
        public Motorcycle Motorcycles { get; set; }

        public string User { get; set; }
    }
}
