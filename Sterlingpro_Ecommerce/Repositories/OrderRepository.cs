using Sterlingpro_Ecommerce.Data;
using Sterlingpro_Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Sterlingpro_Ecommerce.Repositories
{
   
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context) => _context = context;

        public async Task SubmitOrderAsync(int userId)
        {
            var cartItems = await _context.CartItems.Include(c => c.Product).Where(c => c.UserId == userId).ToListAsync();
            if (!cartItems.Any()) return;

            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.UtcNow,
                OrderDetails = cartItems.Select(ci => new OrderDetail
                {
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity,
                    Price = ci.Product.Price
                }).ToList()
            };

            _context.Orders.Add(order);
            _context.CartItems.RemoveRange(cartItems);
            await _context.SaveChangesAsync();
        }
    }
}
