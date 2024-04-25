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

        public void AddItem(int cartId, Product item)
        {
            var cartItems = _cartDal.GetCartItems(cartId);
            var cartItem = cartItems.FirstOrDefault(i => i.ProductId == item.ProductId);
            if (cartItem == null)
            {
                item.ProductId = cartId;
                _cartDal.Insert(item);
            }
            else
            {
                cartItem.Amount += item.Amount;
                _cartDal.Update(cartItem);
            }
        }

        public IEnumerable<Product> GetCartItems(int cartId)
        {
            return _cartDal.GetCartItems(cartId);
        }

        public void RemoveItem(int cartId, Product item)
        {
            var cartItems = _cartDal.GetCartItems(cartId);
            
            var cartItem = cartItems.FirstOrDefault(i => i.ProductId == item.ProductId) ?? throw new CartItemHasNotBeenFoundException("Item has not been found");

            if (cartItem.Amount >= item.Amount)
            {
                cartItem.Amount -= item.Amount;
                if (cartItem.Amount == 0)
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
    }
}
