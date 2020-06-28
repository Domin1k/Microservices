namespace PetFoodShop.Foods.Controllers.Models
{
    using System.ComponentModel.DataAnnotations;

    public class FoodPriceInputModel
    {
        public int FoodId { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
    }
}
