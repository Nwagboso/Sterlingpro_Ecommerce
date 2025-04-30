using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sterlingpro_Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => new { x.UserId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "Electronics", "Devices and gadgets" },
                    { 2, "Clothing", "Wearables and fashion" },
                    { 3, "Books", "Literature and study" },
                    { 4, "Home & Kitchen", "Appliances and décor" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Price", "ProductName", "ProductUrl" },
                values: new object[,]
                {
                    { 1, 1, "Latest smartphone", 699m, "Smartphone", "images/smartphone.jpg" },
                    { 2, 1, "High performance laptop", 1099m, "Laptop", "images/laptop.jpg" },
                    { 3, 1, "Wireless sound", 99m, "Bluetooth Speaker", "images/speaker.jpg" },
                    { 4, 1, "Track your health", 199m, "Smartwatch", "images/watch.jpg" },
                    { 5, 1, "Portable computing", 349m, "Tablet", "images/tablet.jpg" },
                    { 6, 1, "Compact audio", 129m, "Wireless Earbuds", "images/earbuds.jpg" },
                    { 7, 2, "Casual wear", 25m, "Men's T-shirt", "images/mens-tshirt.jpg" },
                    { 8, 2, "Summer fashion", 45m, "Women's Dress", "images/womens-dress.jpg" },
                    { 9, 2, "Slim fit jeans", 60m, "Jeans", "images/jeans.jpg" },
                    { 10, 2, "Comfortable shoes", 80m, "Sneakers", "images/sneakers.jpg" },
                    { 11, 2, "Winter wear", 120m, "Jacket", "images/jacket.jpg" },
                    { 12, 2, "Stylish cap", 15m, "Cap", "images/cap.jpg" },
                    { 13, 3, "Learn C#", 39m, "C# Programming", "images/csharp-book.jpg" },
                    { 14, 3, "Web development", 49m, "ASP.NET Core", "images/aspnet-book.jpg" },
                    { 15, 3, "Master EF Core", 35m, "EF Core", "images/efcore-book.jpg" },
                    { 16, 3, "LINQ explained", 32m, "LINQ in Action", "images/linq-book.jpg" },
                    { 17, 3, "Code quality tips", 45m, "Clean Code", "images/clean-code.jpg" },
                    { 18, 3, "Best practices", 55m, "Design Patterns", "images/design-patterns.jpg" },
                    { 19, 4, "Fast cooking", 199m, "Microwave", "images/microwave.jpg" },
                    { 20, 4, "Smoothies and more", 89m, "Blender", "images/blender.jpg" },
                    { 21, 4, "Comfortable seating", 499m, "Sofa", "images/sofa.jpg" },
                    { 22, 4, "10-piece set", 129m, "Cookware Set", "images/cookware.jpg" },
                    { 23, 4, "Home cleaning", 159m, "Vacuum Cleaner", "images/vacuum.jpg" },
                    { 24, 4, "Modern design", 49m, "Wall Clock", "images/clock.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
