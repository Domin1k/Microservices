namespace PetFoodShop.Statistics.Domain.Models
{
    using PetFoodShop.Domain.Models;

    public class FoodView : Entity<int>
    {
        internal FoodView(string userId, int foodId)
        {
            this.UserId = userId;
            this.FoodId = foodId;
        }

        public string UserId { get; private set; }

        public int FoodId { get; private set; }
    }
}
