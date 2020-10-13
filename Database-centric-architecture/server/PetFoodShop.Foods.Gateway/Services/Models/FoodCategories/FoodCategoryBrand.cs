namespace PetFoodShop.Foods.Gateway.Services.Models.FoodCategories
{
    public class FoodCategoryBrand
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public int TotalFoods { get; set; }
    }
}
