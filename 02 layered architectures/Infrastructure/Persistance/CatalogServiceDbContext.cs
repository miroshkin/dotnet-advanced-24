using Carting.Service;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class CatalogServiceDbContext : DbContext
{
    public CatalogServiceDbContext(DbContextOptions<CatalogServiceDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Items { get; set; }
}