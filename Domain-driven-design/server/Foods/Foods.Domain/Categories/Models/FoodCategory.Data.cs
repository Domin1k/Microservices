namespace PetFoodShop.Foods.Domain.Categories.Models
{
    using System;
    using System.Collections.Generic;
    using PetFoodShop.Domain;

    public class FoodCategoryData : IInitialData
    {
        public Type EntityType => typeof(FoodCategory);

        public IEnumerable<object> GetData()
        => new List<FoodCategory>
        {
            new FoodCategory("Dog"),
            new FoodCategory("Cat"),
            new FoodCategory("Bird" ),
        };
    }
}
