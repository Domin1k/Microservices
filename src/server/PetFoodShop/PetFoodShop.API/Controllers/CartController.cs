namespace PetFoodShop.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.API.Controllers.Models.User;
    using PetFoodShop.API.Infrastructure.Extensions;
    using PetFoodShop.API.Services.Cart;
    using PetFoodShop.API.Services.Exceptions;
    using PetFoodShop.API.Services.Models.Cart;
    using PetFoodShop.Controllers;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("cart")]
    public class CartController : ApiController
    {
        private readonly ICartService userService;

        public CartController(ICartService userService)
        {
            this.userService = userService;
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
                await this.userService.CheckoutCartAsync(this.User.GetId(), new CartModel(cartItems, model.DeliveryAddress));
                return this.Ok();
            }
            catch (CheckoutFailedException ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}
