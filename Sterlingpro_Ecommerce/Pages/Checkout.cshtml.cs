using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sterlingpro_Ecommerce.Repositories;
namespace Sterlingpro_Ecommerce.Pages
{
    public class CheckoutModel : PageModel
    {
        private readonly ICartRepository _cartRepo;
        private readonly IOrderRepository _orderRepo;

        public decimal TotalAmount { get; set; }

        public CheckoutModel(ICartRepository cartRepo, IOrderRepository orderRepo)
        {
            _cartRepo = cartRepo;
            _orderRepo = orderRepo;
        }
        public async Task OnGetAsync()
        {
            var userId = HttpContext.Session.GetInt32("UserId") ?? 0;  // Simulated logged-in user
            var items = await _cartRepo.GetCartItemsAsync(userId);
            TotalAmount = items.Sum(i => i.Quantity * i.Product.Price);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userId = HttpContext.Session.GetInt32("UserId") ?? 0; // Simulated logged-in user
            await _orderRepo.SubmitOrderAsync(userId);
            return RedirectToPage("Submitted");
        }
    }

}
