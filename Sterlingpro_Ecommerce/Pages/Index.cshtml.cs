using Sterlingpro_Ecommerce.Models;
using Sterlingpro_Ecommerce.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sterlingpro_Ecommerce.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public IndexModel(ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }
        public IList<Product> Products { get; set; }

        public async Task OnGetAsync()
        {
            Products = (await _productRepository.GetAllAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int productId)
        {
            // Logic to add product to cart
            //var userId = User.Identity?.Name ?? "guest"; // Replace with real logic
            var userId = HttpContext.Session.GetInt32("UserId") ?? 0;

            if (userId == null || userId == 0)
            {
                return RedirectToPage("Login");
            }

            await _cartRepository.AddToCartAsync(userId, productId);
            return RedirectToPage("Cart");
           
        }
    }

}



