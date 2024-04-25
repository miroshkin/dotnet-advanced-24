using Carting.Service.BLL;
using Microsoft.AspNetCore.Mvc;

namespace Carting.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ILogger<CartController> _logger;
        private readonly ICartBll _cartBll;

        public CartController(ILogger<CartController> logger, ICartBll cartBll)
        {
            _logger = logger;
            _cartBll = cartBll;
        }

        [HttpGet(Name = "GetCarts")]
        public IEnumerable<Item> Get(int cartId)
        {
            return _cartBll.GetCartItems(cartId);
        }

        [HttpPost(Name = "AddItemToCart")]
        public void AddItem(int cartId, Item item)
        {
            _cartBll.AddItem(cartId, item);
        }

        [HttpDelete(Name = "RemoveItemFromCart")]
        public void RemoveItem(int cartId, Item item)
        {
            _cartBll.RemoveItem(cartId, item);
        }

        [HttpPatch(Name = "SeedItemsToCart")]
        public void SeedItems()
        {
            _cartBll.Seed();
        }
    }
}