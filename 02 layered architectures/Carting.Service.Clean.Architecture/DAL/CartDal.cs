using Carting.Service.Configuration;
using LiteDB;
using Microsoft.Extensions.Options;

namespace Carting.Service.DAL;

public class CartDal : ICartDal
{
    private readonly IOptions<LiteDbConfiguration> _options;

    public CartDal(IOptions<LiteDbConfiguration> options)
    {
        _options = options;
    }

    public IEnumerable<Product> GetCartItems(int cartId)
    {
        using var db = new LiteDatabase(_options.Value.ConnectionString);
        var collection = db.GetCollection<Product>(TableNames.CartItems);
        return collection.Find(item => item.ProductId == cartId).ToList();
    }

    public void Insert(Product item)
    {
        using var db = new LiteDatabase(_options.Value.ConnectionString);
        var collection = db.GetCollection<Product>(TableNames.CartItems);
        collection.Insert(item);
    }

    public void Update(Product item)
    {
        using var db = new LiteDatabase(_options.Value.ConnectionString);
        var collection = db.GetCollection<Product>(TableNames.CartItems);
        collection.Update(item);
    }

    public void Delete(Product item)
    {
        using var db = new LiteDatabase(_options.Value.ConnectionString);
        var collection = db.GetCollection<Product>(TableNames.CartItems);
        collection.DeleteMany(c => c.ProductId == item.ProductId & c.ProductId == item.ProductId);
    }

    public void Seed()
    {
        using var db = new LiteDatabase(_options.Value.ConnectionString);
        var cartItems = db.GetCollection<Product>(TableNames.CartItems);
        
        if (cartItems.Count() != 0)
        {
            cartItems.DeleteAll();
        }
    }
}