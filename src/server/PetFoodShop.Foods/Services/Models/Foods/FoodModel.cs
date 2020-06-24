namespace PetFoodShop.Foods.Services.Models
{
    using PetFoodShop.Foods.Data.Models;
    using PetFoodShop.Models;

    public class FoodModel : IMapFrom<Food>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public int FoodBrandId { get; set; }
    }
}
