using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sterlingpro_Ecommerce.Data;
using Microsoft.EntityFrameworkCore;

namespace Sterlingpro_Ecommerce.Pages
{
   
    

    public class LoginModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public LoginModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == Email && u.Password == Password);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }

            // Simulate login by storing user ID in TempData or Session
            //TempData["UserId"] = user.Id;
            HttpContext.Session.SetInt32("UserId", user.Id);
            return RedirectToPage("/Index");
        }
    }

}
