namespace PetFoodShop.Cart.Controllers.Models
{
    using System.Collections.Generic;

    public class CartInputModel
    {
        public IEnumerable<CartDetailsModel> Cart { get; set; }

        public string DeliveryAddress { get; set; }
    }
}
