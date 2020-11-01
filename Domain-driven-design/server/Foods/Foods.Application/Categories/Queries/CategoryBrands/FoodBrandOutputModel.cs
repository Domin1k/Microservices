namespace PetFoodShop.Foods.Application.Categories.Queries.CategoryBrands
{
    using Domain.Categories.Models;
    using PetFoodShop.Application.Mapping;

    public class FoodBrandOutputModel : IMapFrom<FoodBrand>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
