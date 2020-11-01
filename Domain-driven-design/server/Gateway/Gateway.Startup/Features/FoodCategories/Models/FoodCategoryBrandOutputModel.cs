namespace PetFoodShop.Gateway.Startup.Features.FoodCategories.Models
{
    using System.Collections.Generic;

    public class FoodCategoryBrandOutputModel 
    {
        public int CategoryId { get; set; }

        public int TotalFoods { get; set; }

        public IEnumerable<FoodBrandOutputModel> Brands { get; set; }
    }
}
