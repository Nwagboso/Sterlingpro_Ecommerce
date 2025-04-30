using Sterlingpro_Ecommerce.Data;
using Sterlingpro_Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Sterlingpro_Ecommerce.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;
        public CartRepository(AppDbContext context) => _context = context;

        public async Task<List<CartItem>> GetCartItemsAsync(int userId)
            => await _context.CartItems.Include(c => c.Product).Where(c => c.UserId == userId).ToListAsync();

        public async Task AddToCartAsync(int userId, int productId)
        {
            var item = await _context.CartItems.FirstOrDefaultAsync(c => c.UserId == userId && c.ProductId == productId);
            if (item != null) item.Quantity++;
            else _context.CartItems.Add(new CartItem { UserId = userId, ProductId = productId, Quantity = 1 });
            await _context.SaveChangesAsync();
        }

        public async Task UpdateQuantityAsync(int userId, int productId, int quantity)
        {
            var item = await _context.CartItems.FirstOrDefaultAsync(c => c.UserId == userId && c.ProductId == productId);
            if (item != null) { item.Quantity = quantity; await _context.SaveChangesAsync(); }
        }

        public async Task RemoveFromCartAsync(int userId, int productId)
        {
            var item = await _context.CartItems.FirstOrDefaultAsync(c => c.UserId == userId && c.ProductId == productId);
            if (item != null) _context.CartItems.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
