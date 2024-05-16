using System.Net;
using Asp.Versioning;
using Carting.Service.BLL;
using Microsoft.AspNetCore.Mvc;

namespace Carting.Service.Controllers.V1
{

    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
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
            var cartInfo = _cartBll.GetCartInfo(cartId);
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
            try
            {
                _cartBll.AddItem(cartId, item);
                return new OkResult();
            }
            catch
            {
                return StatusCode(505);
            }
        }




        [HttpDelete(Name = "RemoveItemFromCart")]
        public IActionResult RemoveItem(string cartId, Item item)
        {
            try
            {
                _cartBll.RemoveItem(cartId, item);
                return new OkResult();

            }
            catch (CartItemHasNotBeenFoundException)
            {
                return new NotFoundResult();
            }
            catch
            {
                return StatusCode(505);
            }
        }

        [HttpPatch(Name = "SeedItemsToCart")]
        public void SeedItems()
        {
            _cartBll.Seed();
        }
    }
}