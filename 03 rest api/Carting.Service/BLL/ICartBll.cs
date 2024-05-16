namespace Carting.Service.BLL;

public interface ICartBll
{
    IEnumerable<Item> GetCartItems(string cartId);

    void AddItem(string cartId, Item item);

    void RemoveItem(string cartId, Item item);

    void Seed();
}