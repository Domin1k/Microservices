﻿namespace PetFoodShop.Foods.Services
{
    using PetFoodShop.Foods.Services.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFoodService
    {
        Task<FoodDetailModel> DetailsAsync(int foodId);

        Task<FoodDetailModel> EditPrice(int foodId, decimal price);

        Task<IEnumerable<FoodModel>> FoodsPerBrand(int brandId);
    }
}
