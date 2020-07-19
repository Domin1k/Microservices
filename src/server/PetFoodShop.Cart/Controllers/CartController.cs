namespace PetFoodShop.Cart.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Cart.Controllers.Models;
    using PetFoodShop.Cart.Infrastructure.Exceptions;
    using PetFoodShop.Cart.Services;
    using PetFoodShop.Cart.Services.Models;
    using PetFoodShop.Controllers;
    using PetFoodShop.Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CartController : ApiController
    {
        private readonly ICartService userService;
        private readonly ICurrentUserService currentUserService;
        private readonly IMapper mapper;

        public CartController(ICartService userService, ICurrentUserService currentUserService, IMapper mapper)
        {
            this.userService = userService;
            this.currentUserService = currentUserService;
            this.mapper = mapper;
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout(CartInputModel model)
        {
            try
            {
                var cartItems = this.mapper.Map<List<CartItemModel>>(model.Cart);
                var shippmentModel = await this.userService.CheckoutCartAsync(this.currentUserService.UserId, new CartModel(cartItems, model.DeliveryAddress));
                
                return this.Ok(shippmentModel);
            }
            catch (CheckoutFailedException ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}
