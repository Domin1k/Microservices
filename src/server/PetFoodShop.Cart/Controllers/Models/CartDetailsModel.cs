namespace PetFoodShop.Cart.Controllers.Models
{
    public class CartDetailsModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int ProductQuantity { get; set; }

        public decimal Price { get; set; }
    }
}
