using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sterlingpro_Ecommerce.Data;
using Sterlingpro_Ecommerce.Models;
namespace Sterlingpro_Ecommerce.Pages
{
    
    public class CreateUserModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public User User { get; set; } = new();

        public CreateUserModel(AppDbContext context) => _context = context;

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            // Redirect to login or main product page
            return RedirectToPage("Login");
        }
    }

}
