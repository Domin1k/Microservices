namespace PetFoodShop.Foods.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Foods.Controllers.Models.User;
    using PetFoodShop.Foods.Infrastructure.Extensions;
    using PetFoodShop.Foods.Services.Cart;
    using PetFoodShop.Foods.Services.Exceptions;
    using PetFoodShop.Foods.Services.Models.Cart;
    using PetFoodShop.Controllers;
    using System.Linq;
    using System.Threading.Tasks;
    using PetFoodShop.Services;

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
