namespace PetFoodShop.Statistics.Services.Models
{
    using AutoMapper;
    using PetFoodShop.Models;

    public class StatisticsOutputModel : IMapFrom<Data.Models.Statistics>
    {
        public int TotalFoodViews { get; set; }

        public int TotalFoodBrands { get; set; }

        public void Mapping(Profile mapper)
           => mapper
               .CreateMap<Data.Models.Statistics, StatisticsOutputModel>()
               .ForMember(d => d.TotalFoodViews, cfg => cfg.MapFrom(d => d.TotalFoods));
    }
}
