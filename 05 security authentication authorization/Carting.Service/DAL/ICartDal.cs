using Domain.Entities;

namespace Carting.Service.DAL
    {
    public interface ICartDal
        {
        IEnumerable<Item> GetCartItems(string cartId);

        public IEnumerable<Item> GetCartItems(Product product);

        void Insert(Item item);

        void Update(Item item);

        void Delete(Item item);

        void Seed();
        }
    }