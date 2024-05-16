namespace Carting.Service.DAL
{
    public interface ICartDal
    {
        IEnumerable<Item> GetCartItems(string cartId);

        void Insert(Item item);

        void Update(Item item);

        void Delete(Item item);

        void Seed();
    }
}
