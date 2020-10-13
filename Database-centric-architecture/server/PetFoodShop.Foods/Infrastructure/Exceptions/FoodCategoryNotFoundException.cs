namespace PetFoodShop.Foods.Infrastructure.Exceptions
{
    using System;

    public class FoodCategoryNotFoundException : Exception
    {
        public FoodCategoryNotFoundException(string message) : base(message)
        {
        }
    }
}
