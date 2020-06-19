namespace PetFoodShop.API.Data
{
    public static class Validation
    {
        public static class Common
        {
            public const int MaxNameLength = 50;
            public const int MinNameLength = 2;
        }

        public static class Shippment
        {
            public const int MaxDescriptionLength = 500;
            public const int MinDescriptionLength = 10;
            public const int MinAddressLength = 10;
            public const int MaxAddressLength = 500;
        }

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
