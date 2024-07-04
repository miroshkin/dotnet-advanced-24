using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Carting.Service.Clean.Architecture.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductsAndCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Image", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 1, "image1.jpg", "Category 1", null },
                    { 2, "image2.jpg", "Category 2", null },
                    { 3, "image3.jpg", "Category 3", 1 },
                    { 4, "image4.jpg", "Category 4", 1 },
                    { 5, "image5.jpg", "Category 5", 2 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Amount", "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 10L, 1, "Description of Product 1", "image1.jpg", "Product 1", 19.99m },
                    { 2, 5L, 2, "Description of Product 2", "image2.jpg", "Product 2", 29.99m },
                    { 4, 8L, 2, "Description of Product 4", "image4.jpg", "Product 4", 49.99m },
                    { 5, 12L, 1, "Description of Product 5", "image5.jpg", "Product 5", 59.99m },
                    { 3, 15L, 3, "Description of Product 3", "image3.jpg", "Product 3", 39.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);
        }
    }
}