namespace PetFoodShop.Foods.Application.Foods.Common
{
    using Domain.Foods.Models;
    using PetFoodShop.Application.Mapping;

    public class FoodDetailModelOutputModel : IMapFrom<Food>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public int BrandId { get; set; }
    }
}
