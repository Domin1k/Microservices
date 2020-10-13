namespace PetFoodShop.Messages.Foods
{
    public class PriceEditedMessage
    {
        public int FoodId { get; set; }

        public decimal Price { get; set; }
    }
}
