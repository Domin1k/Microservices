namespace PetFoodShop.Statistics.Domain.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using PetFoodShop.Domain.Models;

    public class Statistics : IAggregateRoot
    {
        private readonly List<FoodView> foodsViews;

        internal Statistics()
        {
            this.TotalFoodBrands = 0;
            this.foodsViews = new List<FoodView>();
        }

        public IReadOnlyCollection<FoodView> FoodViews => this.foodsViews.AsReadOnly();

        public int TotalFoods { get; private set; }

        public int TotalFoodBrands { get; private set; }

        public int GetTotalViewPerFood(int foodId)
            => this.foodsViews.Count(x => x.FoodId == foodId);

        public Statistics IncrementTotalFoodBrands()
        {
            this.TotalFoodBrands += 1;
            return this;
        }

        public Statistics AddFoodView(int foodId, string userId)
        {
            this.foodsViews.Add(new FoodView(userId, foodId));
            this.TotalFoods += 1;

            return this;
        }
    }
}
