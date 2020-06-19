namespace PetFoodShop.API.Controllers.Models.User
{
    using System.Collections.Generic;

    public class CartInputModel
    {
        public IEnumerable<CartDetailsModel> Cart { get; set; }

        public string DeliveryAddress { get; set; }
    }
}
