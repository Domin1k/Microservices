using System;
namespace PetFoodShop.Admin.Services.Models.Foods
{
    using System.ComponentModel.DataAnnotations;

    public class FoodPriceInputModel
    {
        public int FoodId { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
    }
}
