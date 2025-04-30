using Sterlingpro_Ecommerce.Data;
using Sterlingpro_Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Sterlingpro_Ecommerce.Pages
{
    // ProductForm.cshtml.cs
    public class ProductFormModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        [BindProperty] public Product Product { get; set; } = new();
        public List<Product> Products { get; set; } = new();
        [BindProperty] public IFormFile? ImageFile { get; set; }
        public SelectList Categories { get; set; } = null!;

        public ProductFormModel(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task OnGetAsync(int? id)
        {
            Categories = new SelectList(await _context.Categories.ToListAsync(), "Id", "CategoryName");
            Products = await _context.Products.Include(p => p.Category).ToListAsync();

            if (id.HasValue)
            {
                var prod = await _context.Products.FindAsync(id);
                if (prod != null) Product = prod;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Categories = new SelectList(await _context.Categories.ToListAsync(), "Id", "CategoryName");
                Products = await _context.Products.Include(p => p.Category).ToListAsync();
                return Page();
            }

            if (ImageFile != null)
            {
                var fileName = Path.GetFileName(ImageFile.FileName);
                var savePath = Path.Combine(_env.WebRootPath, "images", fileName);

                using var fileStream = new FileStream(savePath, FileMode.Create);
                await ImageFile.CopyToAsync(fileStream);

                Product.ProductUrl = "/images/" + fileName;
            }

            if (Product.Id == 0)
                _context.Products.Add(Product);
            else
                _context.Products.Update(Product);

            await _context.SaveChangesAsync();
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var prod = await _context.Products.FindAsync(id);
            if (prod != null)
            {
                _context.Products.Remove(prod);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }

}
