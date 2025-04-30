using Microsoft.EntityFrameworkCore;
using Sterlingpro_Ecommerce.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Sterlingpro_Ecommerce.Data
{
  
   public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<User> Users => Set<User>();
        public DbSet<CartItem> CartItems => Set<CartItem>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CartItem>().HasKey(c => new { c.UserId, c.ProductId });
            modelBuilder.Entity<OrderDetail>().HasKey(od => new { od.OrderId, od.ProductId });


            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, CategoryName = "Electronics", Description = "Devices and gadgets" },
                new Category { Id = 2, CategoryName = "Clothing", Description = "Wearables and fashion" },
                new Category { Id = 3, CategoryName = "Books", Description = "Literature and study" },
                new Category { Id = 4, CategoryName = "Home & Kitchen", Description = "Appliances and décor" }
            );

            // Seed Products (6 per category)
            modelBuilder.Entity<Product>().HasData(
                // Electronics
                new Product { Id = 1, CategoryId = 1, ProductName = "Smartphone", Description = "Latest smartphone", Price = 699, ProductUrl = "images/smartphone.jpg" },
                new Product { Id = 2, CategoryId = 1, ProductName = "Laptop", Description = "High performance laptop", Price = 1099, ProductUrl = "images/laptop.jpg" },
                new Product { Id = 3, CategoryId = 1, ProductName = "Bluetooth Speaker", Description = "Wireless sound", Price = 99, ProductUrl = "images/speaker.jpg" },
                new Product { Id = 4, CategoryId = 1, ProductName = "Smartwatch", Description = "Track your health", Price = 199, ProductUrl = "images/watch.jpg" },
                new Product { Id = 5, CategoryId = 1, ProductName = "Tablet", Description = "Portable computing", Price = 349, ProductUrl = "images/tablet.jpg" },
                new Product { Id = 6, CategoryId = 1, ProductName = "Wireless Earbuds", Description = "Compact audio", Price = 129, ProductUrl = "images/earbuds.jpg" },

                // Clothing
                new Product { Id = 7, CategoryId = 2, ProductName = "Men's T-shirt", Description = "Casual wear", Price = 25, ProductUrl = "images/mens-tshirt.jpg" },
                new Product { Id = 8, CategoryId = 2, ProductName = "Women's Dress", Description = "Summer fashion", Price = 45, ProductUrl = "images/womens-dress.jpg" },
                new Product { Id = 9, CategoryId = 2, ProductName = "Jeans", Description = "Slim fit jeans", Price = 60, ProductUrl = "images/jeans.jpg" },
                new Product { Id = 10, CategoryId = 2, ProductName = "Sneakers", Description = "Comfortable shoes", Price = 80, ProductUrl = "images/sneakers.jpg" },
                new Product { Id = 11, CategoryId = 2, ProductName = "Jacket", Description = "Winter wear", Price = 120, ProductUrl = "images/jacket.jpg" },
                new Product { Id = 12, CategoryId = 2, ProductName = "Cap", Description = "Stylish cap", Price = 15, ProductUrl = "images/cap.jpg" },

                // Books
                new Product { Id = 13, CategoryId = 3, ProductName = "C# Programming", Description = "Learn C#", Price = 39, ProductUrl = "images/csharp-book.jpg" },
                new Product { Id = 14, CategoryId = 3, ProductName = "ASP.NET Core", Description = "Web development", Price = 49, ProductUrl = "images/aspnet-book.jpg" },
                new Product { Id = 15, CategoryId = 3, ProductName = "EF Core", Description = "Master EF Core", Price = 35, ProductUrl = "images/efcore-book.jpg" },
                new Product { Id = 16, CategoryId = 3, ProductName = "LINQ in Action", Description = "LINQ explained", Price = 32, ProductUrl = "images/linq-book.jpg" },
                new Product { Id = 17, CategoryId = 3, ProductName = "Clean Code", Description = "Code quality tips", Price = 45, ProductUrl = "images/clean-code.jpg" },
                new Product { Id = 18, CategoryId = 3, ProductName = "Design Patterns", Description = "Best practices", Price = 55, ProductUrl = "images/design-patterns.jpg" },

                // Home & Kitchen
                new Product { Id = 19, CategoryId = 4, ProductName = "Microwave", Description = "Fast cooking", Price = 199, ProductUrl = "images/microwave.jpg" },
                new Product { Id = 20, CategoryId = 4, ProductName = "Blender", Description = "Smoothies and more", Price = 89, ProductUrl = "images/blender.jpg" },
                new Product { Id = 21, CategoryId = 4, ProductName = "Sofa", Description = "Comfortable seating", Price = 499, ProductUrl = "images/sofa.jpg" },
                new Product { Id = 22, CategoryId = 4, ProductName = "Cookware Set", Description = "10-piece set", Price = 129, ProductUrl = "images/cookware.jpg" },
                new Product { Id = 23, CategoryId = 4, ProductName = "Vacuum Cleaner", Description = "Home cleaning", Price = 159, ProductUrl = "images/vacuum.jpg" },
                new Product { Id = 24, CategoryId = 4, ProductName = "Wall Clock", Description = "Modern design", Price = 49, ProductUrl = "images/clock.jpg" }
            );
        }

    }
}

