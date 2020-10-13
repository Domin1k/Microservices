namespace PetFoodShop.Foods.Services.Models
{
    using AutoMapper;
    using PetFoodShop.Models;
    using System.Linq;

    public class FoodCategoryBrand : IMapFrom<Data.Models.FoodBrand>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public int TotalFoods { get; set; }

        public void Mapping(Profile mapper)
            => mapper
                .CreateMap<Data.Models.FoodBrand, FoodCategoryBrand>()
                .ForMember(d => d.CategoryId, cfg => cfg.MapFrom(d => d.FoodCategoryId))
                .ForMember(d => d.TotalFoods, cfg => cfg.MapFrom(d => d.Foods.Count()));
    }
}
