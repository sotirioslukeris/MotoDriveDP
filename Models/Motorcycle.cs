using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ASPMotoDrive.Models
{
    public class Motorcycle
    {
        public int Id { get; set; }
       
        public int ModelId { get; set; }
        public Model Models { get; set; }
        public TypeUsage TypeUsage { get; set; }
        public string CatalogueNumber { get; set; }
        public int EnginePower { get; set; }
        public string ImageURL { get; set; }
        public double Price { get; set; }
        public TypeMotor TypeMotor { get; set; }
        public string Description { get; set; }
        public DateTime LastUpdate { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}