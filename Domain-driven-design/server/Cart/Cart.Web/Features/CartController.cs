namespace PetFoodShop.Cart.Web.Features
{
    using Application.Commands.CheckoutCart;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Web.Controllers.v1;
    using System.Threading.Tasks;

    public class CartController : ApiController
    {
        [Authorize]
        [HttpPost(nameof(Checkout))]
        public async Task<ActionResult<CheckoutCartOutputModel>> Checkout(CheckoutCartCommand command)
            => await this.Send(command);
    }
}
