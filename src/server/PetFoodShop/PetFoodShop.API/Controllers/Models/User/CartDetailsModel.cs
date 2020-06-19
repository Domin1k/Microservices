namespace PetFoodShop.API.Controllers.Models.User
{
    public class CartDetailsModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int ProductQuantity { get; set; }

        public decimal Price { get; set; }
    }
}
