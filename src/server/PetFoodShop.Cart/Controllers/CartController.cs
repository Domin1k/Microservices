namespace PetFoodShop.Cart.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Cart.Controllers.Models;
    using PetFoodShop.Cart.Infrastructure.Exceptions;
    using PetFoodShop.Cart.Services;
    using PetFoodShop.Cart.Services.Models;
    using PetFoodShop.Controllers;
    using PetFoodShop.Services;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("cart")]
    public class CartController : ApiController
    {
        private readonly ICartService userService;
        private readonly ICurrentUserService currentUserService;

        public CartController(ICartService userService, ICurrentUserService currentUserService)
        {
            this.userService = userService;
            this.currentUserService = currentUserService;
        }

        [HttpPost]
        [Route("checkout")]
        public async Task<IActionResult> Checkout(CartInputModel model)
        {
            try
            {
                var cartItems = model.Cart.Select(x => new CartItemModel()
                {
                    Id = x.ProductId,
                    Name = x.ProductName,
                    Price = x.Price,
                    Quantity = x.ProductQuantity
                });
                await this.userService.CheckoutCartAsync(this.currentUserService.UserId, new CartModel(cartItems, model.DeliveryAddress));
                return this.Ok();
            }
            catch (CheckoutFailedException ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}
