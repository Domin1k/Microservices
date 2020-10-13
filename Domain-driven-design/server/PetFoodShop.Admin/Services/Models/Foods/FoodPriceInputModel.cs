using System;
namespace PetFoodShop.Admin.Services.Models.Foods
{
    using System.ComponentModel.DataAnnotations;

    public class FoodPriceInputModel
    {
        public FoodPriceInputModel()
        {
        }

        public FoodPriceInputModel(int foodId, decimal price)
        {
            FoodId = foodId;
            Price = price;
        }

        public int FoodId { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
    }
}
