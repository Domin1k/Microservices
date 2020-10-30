namespace PetFoodShop.Foods.Domain.Categories.Models
{
    using System;
    using System.Collections.Generic;
    using PetFoodShop.Domain;

    public class FoodBrandData : IInitialData
    {
        public Type EntityType => typeof(FoodBrand);

        public IEnumerable<object> GetData()
        => new List<FoodBrand>
        {
            new FoodBrand("Royal Canin" ),
            new FoodBrand("Applaws" ),
            new FoodBrand("ARDEN GRANGE" ),
        };
    }
}
