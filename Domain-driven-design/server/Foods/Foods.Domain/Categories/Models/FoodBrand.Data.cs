namespace PetFoodShop.Foods.Domain.Categories.Models
{
    using System;
    using System.Collections.Generic;
    using PetFoodShop.Domain;

    public class FoodBrandData : IInitialData
    {
        public Type EntityType => typeof(FoodBrand);

        public IEnumerable<object> GetData() => new List<FoodBrand>();
        //=> new List<FoodBrand>
        //{
        //    new FoodBrand { Name = $"Royal Canin", Foods = foodRC , FoodCategoryId = item.Id },
        //    new FoodBrand { Name = $"Royal Canin Veterinary Diet", Foods = foodRC , FoodCategoryId = item.Id},
        //    new FoodBrand { Name = $"Applaws", FoodCategoryId = item.Id },
        //    new FoodBrand { Name = $"ARDEN GRANGE", Foods = foodArden , FoodCategoryId = item.Id },
        //    new FoodBrand { Name = $"Hill's Prescription Diet" , FoodCategoryId = item.Id },
        //    new FoodBrand { Name = $"Hill's Science Plan Dry {item.Name} Food", FoodCategoryId = item.Id  },
        //    new FoodBrand { Name = $"IAMS {item.Name} Food" , FoodCategoryId = item.Id },
        //    new FoodBrand { Name = $"James Wellbeloved {item.Name} Food" , FoodCategoryId = item.Id }
        //};
    }
}
