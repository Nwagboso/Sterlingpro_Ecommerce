using Sterlingpro_Ecommerce.Models;
using Sterlingpro_Ecommerce.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sterlingpro_Ecommerce.Data;

namespace Sterlingpro_Ecommerce.Pages
{
    public class CartModel : PageModel
    {
        private readonly ICartRepository _cartRepo;

        public List<CartItem> CartItems { get; set; } = new();

        public CartModel(ICartRepository cartRepo)
        {
            _cartRepo = cartRepo;
        }

        public async Task OnGetAsync()
        {
            var userId = HttpContext.Session.GetInt32("UserId") ?? 0; // Simulated logged-in user
            CartItems = await _cartRepo.GetCartItemsAsync(userId);
        }

        public async Task<IActionResult> OnPostIncreaseAsync(int productId)
        {
            var userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            await _cartRepo.AddToCartAsync(userId, productId);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDecreaseAsync(int productId)
        {
            var userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            var item = (await _cartRepo.GetCartItemsAsync(userId))
                        .FirstOrDefault(c => c.ProductId == productId);

            if (item != null && item.Quantity > 1)
            {
                await _cartRepo.UpdateQuantityAsync(userId, productId, item.Quantity - 1);
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRemoveAsync(int productId)
        {
            var userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            await _cartRepo.RemoveFromCartAsync(userId, productId);
            return RedirectToPage();
        }
    }

}


