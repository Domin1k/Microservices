namespace PetFoodShop.Cart.Application.Commands.CheckoutCart
{
    using System.Collections.Generic;

    public class CheckoutCartCommandInputModel
    {
        public IEnumerable<CartDetailsModelInputModel> Cart { get; set; }

        public string DeliveryAddress { get; set; }
    }
}
