using Sterlingpro_Ecommerce.Models;

namespace Sterlingpro_Ecommerce.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new();
    }
}

