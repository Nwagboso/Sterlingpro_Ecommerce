namespace Sterlingpro_Ecommerce.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ProductUrl { get; set; } = string.Empty;
        public Category Category { get; set; } = null!;
    }
}


