namespace PetFoodShop.Admin.Services.Models.Foods
{
    public class FoodCategoryBrand
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public int TotalFoods { get; set; }
    }
}
