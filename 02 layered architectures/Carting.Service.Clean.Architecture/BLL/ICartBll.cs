namespace Carting.Service.BLL;

public interface ICartBll
{
    IEnumerable<Product> GetCartItems(int cartId);

    void AddItem(int cartId, Product item);

    void RemoveItem(int cartId, Product item);
}