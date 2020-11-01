namespace PetFoodShop.Foods.Domain.Categories.Models
{
    using System;
    using System.Collections.Generic;
    using PetFoodShop.Domain;

    public class FoodBrandData : IInitialData
    {
        public const string RoyalCaninBrandName = "Royal Canin";
        public const string ApplawsBrandName = "Applaws";
        public const string ARDENGRANGEBrandName = "ARDEN GRANGE";

        public Type EntityType => typeof(FoodBrand);

        public IEnumerable<object> GetData()
        => new List<FoodBrand>
        {
            new FoodBrand(RoyalCaninBrandName),
            new FoodBrand(ApplawsBrandName),
            new FoodBrand(ARDENGRANGEBrandName),
        };
    }
}
