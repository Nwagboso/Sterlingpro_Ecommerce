using Sterlingpro_Ecommerce.Data;
using Sterlingpro_Ecommerce.Models;

namespace Sterlingpro_Ecommerce.Repositories
{
    public interface ICartRepository
    {
        Task<List<CartItem>> GetCartItemsAsync(int userId);
        Task AddToCartAsync(int userId, int productId);
        Task UpdateQuantityAsync(int userId, int productId, int quantity);
        Task RemoveFromCartAsync(int userId, int productId);
    }
}
