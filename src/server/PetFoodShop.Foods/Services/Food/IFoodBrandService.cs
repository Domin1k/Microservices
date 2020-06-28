namespace PetFoodShop.Foods.Services.Food
{
    using PetFoodShop.Foods.Services.Models.FoodBrand;
    using System.Threading.Tasks;

    public interface IFoodBrandService
    {
        Task<int> Create(BrandModel model);
    }
}
