namespace PetFoodShop.Foods.Application.Categories.Queries.CategoryBrands
{
    using System.Collections.Generic;
    using AutoMapper;
    using Domain.Categories.Models;
    using PetFoodShop.Application.Mapping;

    public class FoodCategoryBrandOutputModel : IMapFrom<FoodCategory>
    {
        public int CategoryId { get; set; }

        public int TotalFoods { get; set; }

        public IEnumerable<FoodBrandOutputModel> Brands { get; set; }

        public void Mapping(Profile profile)
            => profile
                .CreateMap<FoodCategory, FoodCategoryBrandOutputModel>()
                .ForMember(x => x.CategoryId, opt => opt.MapFrom(s => s.Id))
                .ForMember(x => x.Brands, opt => opt.MapFrom(s => s.Brands));
    }
}


