using Carting.Service;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class CartingDBContext : DbContext
{
    public CartingDBContext(DbContextOptions<CartingDBContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Items { get; set; }
}