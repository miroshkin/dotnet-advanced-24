using System.Net;
using Asp.Versioning;
using Carting.Service.BLL;
using Common;
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

        /// <summary>
        /// Gets cart info with cart id and items
        /// </summary>
        /// <param name="cartId">Guid - Unique identifier of a cart</param>
        /// <returns></returns>
        [HttpGet(Name = "GetCartInfo")]
        public ActionResult<CartDto?> Get(string cartId)
        {
            //TODO Receive changes from rabbit mq here
            RabbitMQHelper.ReceiveMessage("catalog_changes");

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
        /// <returns></returns>
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