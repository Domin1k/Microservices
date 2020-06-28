namespace PetFoodShop.Foods.Services.Models.FoodBrand
{
    using PetFoodShop.Foods.Controllers.Models;
    using PetFoodShop.Models;

    public class BrandModel : IMapFrom<BrandInputModel>
    {
        public string Name { get; set; }

        public int FoodCategoryId { get; set; }
    }
}
