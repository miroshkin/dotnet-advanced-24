using Domain.Entities;
using Microsoft.Extensions.Options;

namespace Carting.Service.DAL;

public class CartDal : ICartDal
{
    private readonly CatalogServiceDbContext _catalogServiceDbContext;

    public CartDal(CatalogServiceDbContext context)
    {
        _catalogServiceDbContext = context;
    }

    public IEnumerable<Product> GetCartItems(int cartId)
    {
        return _catalogServiceDbContext.Items.ToList();
    }

    public void Insert(Product item)
    {
        _catalogServiceDbContext.Add(item);
        _catalogServiceDbContext.SaveChanges();
    }

    public void Update(Product item)
    {
        _catalogServiceDbContext.Update(item);
        _catalogServiceDbContext.SaveChanges();
    }

    public void Delete(Product item)
    {
        _catalogServiceDbContext.Remove(item);
        _catalogServiceDbContext.SaveChanges();
    }

}