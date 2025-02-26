using Microsoft.AspNetCore.Identity;

namespace ASPMotoDrive.Models
{
    public class User:IdentityUser
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public ICollection<Order> Orders { get; set; }
        
    }
}