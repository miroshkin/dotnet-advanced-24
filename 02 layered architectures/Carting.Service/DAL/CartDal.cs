﻿using Carting.Service.Configuration;
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

    public IEnumerable<Item> GetCartItems(int cartId)
    {
        using var db = new LiteDatabase(_options.Value.ConnectionString);
        var collection = db.GetCollection<Item>(TableNames.CartItems);
        return collection.Find(item => item.CartId == cartId).ToList();
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
        collection.DeleteMany(c => c.CartId == item.CartId & c.Id == item.Id);
    }

    public void Seed()
    {
        using var db = new LiteDatabase(_options.Value.ConnectionString);
        var cartItems = db.GetCollection<Item>(TableNames.CartItems);
        
        if (cartItems.Count() != 0)
        {
            cartItems.DeleteAll();
        }

        var initItems = new List<Item>(6)
        {
            new Item(){CartId = 1, Id = 1, Image = new Image(){AlternativeText = "AltText1", Url = "url1"}, Name = "Tomato", Price = 100, Quantity = 1},
            new Item(){CartId = 1, Id = 2, Image = new Image(){AlternativeText = "AltText2", Url = "url2"}, Name = "Cucumber", Price = 200, Quantity = 2},
            new Item(){CartId = 1, Id = 3, Image = new Image(){AlternativeText = "AltText3", Url = "url3"}, Name = "Banana", Price = 300, Quantity = 3},
            new Item(){CartId = 2, Id = 4, Image = new Image(){AlternativeText = "AltText4", Url = "url4"}, Name = "Meat", Price = 400, Quantity = 4},
            new Item(){CartId = 2, Id = 5, Image = new Image(){AlternativeText = "AltText5", Url = "url5"}, Name = "Milk", Price = 500, Quantity = 5},
            new Item(){CartId = 2, Id = 6, Image = new Image(){AlternativeText = "AltText6", Url = "url6"}, Name = "Tomato", Price = 600, Quantity = 6},
        };

        initItems.ForEach(i => cartItems.Insert(i));
    }
}