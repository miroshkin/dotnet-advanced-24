using System.Net;
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
        public ActionResult<CartDto?> Get(string cartId)
        {
            var cartInfo =_cartBll.GetCartInfo(cartId);
            if (cartInfo == null)
            {
                return NotFound();
            }
            else
            {
                return cartInfo;
            }
        }

        [HttpPost(Name = "AddItemToCart")]
        public ActionResult AddItem(string cartId, Item item)
        {
            _cartBll.AddItem(cartId, item);
            return CreatedAtRoute("AddItemToCart", new { Id = item.Id }, item);
        }




        [HttpDelete(Name = "RemoveItemFromCart")]
        public void RemoveItem(string cartId, Item item)
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