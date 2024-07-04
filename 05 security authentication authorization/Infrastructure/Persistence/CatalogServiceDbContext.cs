using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
    {
    public class CatalogServiceDbContext : DbContext
        {
        public CatalogServiceDbContext(DbContextOptions<CatalogServiceDbContext> options) : base(options)
            {
            }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            SeedData(modelBuilder);
            }

        private void SeedData(ModelBuilder modelBuilder)
            {
            // Call your data seeding method
            SeedCategories(modelBuilder);
            // Add more seeding methods if needed for other entities
            }

        private void SeedCategories(ModelBuilder modelBuilder)
            {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Category 1", Image = "image1.jpg", ParentCategoryId = null },
                new Category { CategoryId = 2, Name = "Category 2", Image = "image2.jpg", ParentCategoryId = null },
                new Category { CategoryId = 3, Name = "Category 3", Image = "image3.jpg", ParentCategoryId = 1 },
                new Category { CategoryId = 4, Name = "Category 4", Image = "image4.jpg", ParentCategoryId = 1 },
                new Category { CategoryId = 5, Name = "Category 5", Image = "image5.jpg", ParentCategoryId = 2 }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                    {
                    ProductId = 1,
                    Name = "Product 1",
                    Description = "Description of Product 1",
                    Image = "image1.jpg",
                    CategoryId = 1, // Assuming CategoryId 1 exists
                    Price = 19.99m,
                    Amount = 10
                    },
                new Product
                    {
                    ProductId = 2,
                    Name = "Product 2",
                    Description = "Description of Product 2",
                    Image = "image2.jpg",
                    CategoryId = 2, // Assuming CategoryId 2 exists
                    Price = 29.99m,
                    Amount = 5
                    },
                new Product
                    {
                    ProductId = 3,
                    Name = "Product 3",
                    Description = "Description of Product 3",
                    Image = "image3.jpg",
                    CategoryId = 3, // Assuming CategoryId 3 exists
                    Price = 39.99m,
                    Amount = 15
                    },
                new Product
                    {
                    ProductId = 4,
                    Name = "Product 4",
                    Description = "Description of Product 4",
                    Image = "image4.jpg",
                    CategoryId = 2, // Assuming CategoryId 2 exists
                    Price = 49.99m,
                    Amount = 8
                    },
                new Product
                    {
                    ProductId = 5,
                    Name = "Product 5",
                    Description = "Description of Product 5",
                    Image = "image5.jpg",
                    CategoryId = 1, // Assuming CategoryId 1 exists
                    Price = 59.99m,
                    Amount = 12
                    }
            );
            }
        }
    }