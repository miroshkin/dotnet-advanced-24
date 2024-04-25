namespace Carting.Service.BLL;

public interface ICartBll
{
    IEnumerable<Item> GetCartItems(int cartId);

    void AddItem(int cartId, Item item);

    void RemoveItem(int cartId, Item item);

    void Seed();
}