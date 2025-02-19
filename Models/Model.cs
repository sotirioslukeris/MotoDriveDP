namespace ASPMotoDrive.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public Brand Brands { get; set; }
        public DateTime DateRegister{ get; set; }

        public ICollection<Motorcycle> Motorcycles { get; set; }
    }
}
