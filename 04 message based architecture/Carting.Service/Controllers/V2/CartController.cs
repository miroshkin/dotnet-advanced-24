using Asp.Versioning;
using Carting.Service.BLL;
using Common;
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

        /// <summary>
        /// Gets items for the specified cart id 
        /// </summary>
        /// <param name="cartId">Guid - Unique identifier of a cart</param>
        /// <returns></returns>
        [HttpGet(Name = "GetCartInfo")]
        public async Task<ActionResult<IEnumerable<Item>>> Get(string cartId)
        {
            //TODO Receive changes from rabbit mq here
            await RabbitMQHelper.ReceiveMessage("catalog_changes");

            var cartItems =_cartBll.GetCartItems(cartId);
            if (cartItems != null && cartItems.Any())
            {
                return Ok(cartItems);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Adds item to cart. If cart does not exist - creates it.
        /// </summary>
        /// <param name="cartId">Guid - Unique identifier of a cart</param>
        /// <param name="item">Item to be added to the cart</param>
        /// <returns></returns>
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

        /// <summary>
        /// Deletes item from the specified cart
        /// </summary>
        /// <param name="cartId">Guid - Unique identifier of a cart</param>
        /// <param name="item">Item to be deleted to the cart</param>
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

        /// <summary>
        /// Seeds the data into local database
        /// </summary>
        [HttpPatch(Name = "SeedItemsToCart")]
        public void SeedItems()
        {
            _cartBll.Seed();
        }
    }
}