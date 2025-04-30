using Sterlingpro_Ecommerce.Models;

namespace Sterlingpro_Ecommerce.Models
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

}



