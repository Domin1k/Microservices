namespace PetFoodShop.Foods.Services.Models
{
    using AutoMapper;
    using PetFoodShop.Foods.Data.Models;
    using PetFoodShop.Models;
    using System.Linq;

    public class FoodCategoryBrand : IMapFrom<FoodBrand>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public int TotalFoods { get; set; }

        public void Mapping(Profile mapper)
            => mapper
                .CreateMap<FoodBrand, FoodCategoryBrand>()
                .ForMember(d => d.CategoryId, cfg => cfg.MapFrom(d => d.FoodCategoryId))
                .ForMember(d => d.TotalFoods, cfg => cfg.MapFrom(d => d.Foods.Count()));
    }
}
