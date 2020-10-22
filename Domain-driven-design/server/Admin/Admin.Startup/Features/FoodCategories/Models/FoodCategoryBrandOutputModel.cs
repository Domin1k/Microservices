namespace Admin.Startup.Features.FoodCategories.Models
{
    public class FoodCategoryBrandOutputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public int TotalFoods { get; set; }
    }
}
