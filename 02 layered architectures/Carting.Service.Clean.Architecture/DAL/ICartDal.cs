namespace Carting.Service.DAL
{
    public interface ICartDal
    {
        IEnumerable<Product> GetCartItems(int cartId);

        void Insert(Product item);

        void Update(Product item);

        void Delete(Product item);
    }
}
