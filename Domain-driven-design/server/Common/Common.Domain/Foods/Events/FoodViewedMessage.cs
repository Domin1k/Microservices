namespace PetFoodShop.Domain.Foods.Events
{
    public class FoodViewedMessage
    {
        public int FoodId { get; set; }

        public string UserId { get; set; }
    }
}
