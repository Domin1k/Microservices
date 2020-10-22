namespace PetFoodShop.Gateway.Startup.Features.Foods.Models
{
    public class FoodDetailModelOutputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public int FoodBrandId { get; set; }
    }
}
