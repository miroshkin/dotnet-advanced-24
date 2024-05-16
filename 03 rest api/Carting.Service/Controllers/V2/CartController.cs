using Asp.Versioning;
using Carting.Service.BLL;
using Microsoft.AspNetCore.Mvc;

namespace Carting.Service.Controllers.V2
{

    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class CartController : ControllerBase
    {
        private readonly ILogger<CartController> _logger;
        private readonly ICartBll _cartBll;

        public CartController(ILogger<CartController> logger, ICartBll cartBll)
        {
            _logger = logger;
            _cartBll = cartBll;
        }

        [HttpGet(Name = "GetCartInfo")]
        public ActionResult<IEnumerable<Item>> Get(string cartId)
        {
            var cartItems =_cartBll.GetCartItems(cartId);
            if (cartItems.Any())
            {
                return Ok(cartItems);
            }
            else
            {
                return NotFound();
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