using Carting.Service.Configuration;
using Domain.Entities;
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

    public IEnumerable<Item> GetCartItems(string cartId)
        {
        using var db = new LiteDatabase(_options.Value.ConnectionString);
        var collection = db.GetCollection<Item>(TableNames.CartItems);
        return collection.Find(item => item.CartId == cartId).ToList();
        }

    public IEnumerable<Item> GetCartItems(Product product)
        {
        using var db = new LiteDatabase(_options.Value.ConnectionString);
        var collection = db.GetCollection<Item>(TableNames.CartItems);
        return collection.Find(item => item.Name.ToUpper() == product.Name.ToUpper()).ToList();
        }

    public void Insert(Item item)
        {
        using var db = new LiteDatabase(_options.Value.ConnectionString);
        var collection = db.GetCollection<Item>(TableNames.CartItems);
        collection.Insert(item);
        }

    public void Update(Item item)
        {
        using var db = new LiteDatabase(_options.Value.ConnectionString);
        var collection = db.GetCollection<Item>(TableNames.CartItems);
        collection.Update(item);
        }

    public void Delete(Item item)
        {
        using var db = new LiteDatabase(_options.Value.ConnectionString);
        var collection = db.GetCollection<Item>(TableNames.CartItems);
        collection.DeleteMany(c => c.CartId == item.CartId && c.Id == item.Id);
        }

    public void Seed()
        {
        using var db = new LiteDatabase(_options.Value.ConnectionString);

        var cartItems = db.GetCollection<Item>(TableNames.CartItems);

        if (cartItems.Count() != 0)
            {
            db.DropCollection(TableNames.CartItems);
            }

        cartItems.EnsureIndex(x => x.CartId);
        cartItems.EnsureIndex(x => x.Id);

        var initItems = new List<Item>(6)
        {
            new Item(){CartId = "099BD836-1D09-4C11-AE58-D178E8B4FC44", Id = 1, Image = new Image(){AlternativeText = "AltText1", Url = "url1"}, Name = "Tomato", Price = 100, Quantity = 1},
            new Item(){CartId = "099BD836-1D09-4C11-AE58-D178E8B4FC44", Id = 2, Image = new Image(){AlternativeText = "AltText2", Url = "url2"}, Name = "Cucumber", Price = 200, Quantity = 2},
            new Item(){CartId = "099BD836-1D09-4C11-AE58-D178E8B4FC66", Id = 3, Image = new Image(){AlternativeText = "AltText3", Url = "url3"}, Name = "Banana", Price = 300, Quantity = 3},
            new Item(){CartId = "099BD836-1D09-4C11-AE58-D178E8B4FC77", Id = 4, Image = new Image(){AlternativeText = "AltText4", Url = "url4"}, Name = "Meat", Price = 400, Quantity = 4},
            new Item(){CartId = "099BD836-1D09-4C11-AE58-D178E8B4FC77", Id = 5, Image = new Image(){AlternativeText = "AltText5", Url = "url5"}, Name = "Milk", Price = 500, Quantity = 5},
            new Item(){CartId = "099BD836-1D09-4C11-AE58-D178E8B4FC88", Id = 6, Image = new Image(){AlternativeText = "AltText6", Url = "url6"}, Name = "Tomato", Price = 600, Quantity = 6},
        };

        initItems.ForEach(i => cartItems.Insert(i));
        }
    }