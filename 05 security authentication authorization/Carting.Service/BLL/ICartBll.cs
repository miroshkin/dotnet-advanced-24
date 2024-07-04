using Domain.Entities;

namespace Carting.Service.BLL;

public interface ICartBll
    {
    CartDto? GetCartInfo(string cartId);

    IEnumerable<ItemDto>? GetCartItems(string cartId);

    void AddItem(string cartId, Item item);

    void UpdateCarts(Product product);

    void RemoveItem(string cartId, Item item);

    void Seed();
    }