namespace PetFoodShop.Domain.Foods.Events
{
    public class PriceEditedMessage
    {
        public int FoodId { get; set; }

        public decimal Price { get; set; }
    }
}
