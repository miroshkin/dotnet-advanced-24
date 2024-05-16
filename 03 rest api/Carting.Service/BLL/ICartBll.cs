namespace Carting.Service.BLL;

public interface ICartBll
{
    CartDto? GetCartInfo(string cartId);

    IEnumerable<ItemDto>? GetCartItems(string cartId);

    void AddItem(string cartId, Item item);

    void RemoveItem(string cartId, Item item);

    void Seed();
}