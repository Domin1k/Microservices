namespace PetFoodShop.Foods.Infrastructure.Exceptions
{
    using System;

    public class CreateBrandException : Exception
    {
        public CreateBrandException(string message) : base(message)
        {
        }
    }
}
