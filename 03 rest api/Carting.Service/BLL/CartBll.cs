using Carting.Service.DAL;

namespace Carting.Service.BLL
{
    public class CartBll : ICartBll
    {
        private readonly ICartDal _cartDal;

        public CartBll(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public void AddItem(string cartId, Item item)
        {
            var cartItems = _cartDal.GetCartItems(cartId);
            var cartItem = cartItems.FirstOrDefault(i => i.Id == item.Id);
            if (cartItem == null)
            {
                item.CartId = cartId;
                _cartDal.Insert(item);
            }
            else
            {
                cartItem.Quantity += item.Quantity;
                _cartDal.Update(cartItem);
            }
        }

        public IEnumerable<Item> GetCartItems(string cartId)
        {
            return _cartDal.GetCartItems(cartId);
        }

        public void RemoveItem(string cartId, Item item)
        {
            var cartItems = _cartDal.GetCartItems(cartId);
            
            var cartItem = cartItems.FirstOrDefault(i => i.Id == item.Id) ?? throw new CartItemHasNotBeenFoundException("Item has not been found");

            if (cartItem.Quantity >= item.Quantity)
            {
                cartItem.Quantity -= item.Quantity;
                if (cartItem.Quantity == 0)
                {
                    _cartDal.Delete(cartItem);
                    return;
                }
                _cartDal.Update(cartItem);
            }
            else
            {
                throw new CartItemRemoveException("You are trying to delete more items than exist now in the cart");
            }
        }

        public void Seed()
        {
            _cartDal.Seed();
        }
    }
}
