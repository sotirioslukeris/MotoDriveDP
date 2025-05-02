using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ASPMotoDrive.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public string Description { get; set;}
        
        public ICollection<Model> Models { get; set; }
        
    }
}
