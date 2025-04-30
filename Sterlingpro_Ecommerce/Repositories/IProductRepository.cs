
using Sterlingpro_Ecommerce.Models;

namespace Sterlingpro_Ecommerce.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
    }
}
