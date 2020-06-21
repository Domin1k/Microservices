namespace PetFoodShop.Foods.Data
{
    internal static class Validation
    {
        public static class Food
        {
            public const int MaxDescriptionLength = 1500;
            public const int MinQuantity = 1;
            public const int MaxQuantity = 10000;
            public const int MinPrice = 0;
            public const int MaxPrice = int.MaxValue;
        }
    }
}
