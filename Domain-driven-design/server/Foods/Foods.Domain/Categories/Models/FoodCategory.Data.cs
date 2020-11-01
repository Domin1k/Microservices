namespace PetFoodShop.Foods.Domain.Categories.Models
{
    using System;
    using System.Collections.Generic;
    using PetFoodShop.Domain;

    public class FoodCategoryData : IInitialData
    {
        public const string DogCategory = "Dog";
        public const string CatCategory = "Cat";
        public const string BirdCategory = "Bird";
        public Type EntityType => typeof(FoodCategory);

        public IEnumerable<object> GetData()
        => new List<FoodCategory>
        {
            new FoodCategory(DogCategory),
            new FoodCategory(CatCategory),
            new FoodCategory(BirdCategory),
        };
    }
}
