using Sterlingpro_Ecommerce.Data;
using Sterlingpro_Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Sterlingpro_Ecommerce.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) => _context = context;

        public Task<List<Product>> GetAllAsync() => _context.Products.Include(p => p.Category).ToListAsync();
        public Task<Product?> GetByIdAsync(int id) => _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
    }
}
