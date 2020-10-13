namespace PetFoodShop.Foods.Services.Models
{
    public class FoodOutputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public int FoodBrandId { get; set; }
    }
}
