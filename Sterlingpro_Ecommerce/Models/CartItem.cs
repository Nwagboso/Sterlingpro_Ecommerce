using Sterlingpro_Ecommerce.Models;

namespace Sterlingpro_Ecommerce.Data
{
    public class CartItem
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; } = null!;
    }

}
