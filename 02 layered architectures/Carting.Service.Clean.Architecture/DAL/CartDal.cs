using Domain.Entities;
using LiteDB;
using Microsoft.Extensions.Options;

namespace Carting.Service.DAL;

public class CartDal : ICartDal
{
    private readonly CartingDBContext _cartingDBContext;

    public CartDal(CartingDBContext context)
    {
        _cartingDBContext = context;
    }

    public IEnumerable<Product> GetCartItems(int cartId)
    {
        return _cartingDBContext.Items.ToList();
    }

    public void Insert(Product item)
    {
        _cartingDBContext.Add(item);
        _cartingDBContext.SaveChanges();
    }

    public void Update(Product item)
    {
        _cartingDBContext.Update(item);
        _cartingDBContext.SaveChanges();
    }

    public void Delete(Product item)
    {
        _cartingDBContext.Remove(item);
        _cartingDBContext.SaveChanges();
    }

}