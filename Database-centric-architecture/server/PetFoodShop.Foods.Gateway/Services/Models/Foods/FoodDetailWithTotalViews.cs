namespace PetFoodShop.Foods.Gateway.Services.Models.Foods
{
    using PetFoodShop.Foods.Services.Models;
    using PetFoodShop.Models;

    public class FoodDetailWithTotalViews : IMapFrom<FoodDetailModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public int FoodBrandId { get; set; }

        public int TotalViewsCount { get; set; }
    }
}
