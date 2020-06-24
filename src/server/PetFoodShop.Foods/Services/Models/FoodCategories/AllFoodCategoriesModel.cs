namespace PetFoodShop.Foods.Services.Models
{
    using PetFoodShop.Foods.Data.Models;
    using PetFoodShop.Models;

    public class AllFoodCategoriesModel : IMapFrom<FoodCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
