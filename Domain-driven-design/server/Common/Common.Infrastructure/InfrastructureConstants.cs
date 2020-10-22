namespace PetFoodShop.Infrastructure
{
    public static class InfrastructureConstants
    {
        public static class SwaggerConstants
        {
            public const string SwaggerEndpoint = "/swagger/v1/swagger.json";
            public const string SwaggerName = "PetFoodShop API";
        }

        public static class ConfigurationConstants
        {
            public const string DefaultConnectionString = "DefaultConnection";
            public const int DefaultMaxRetryCount = 10;
            public const int DefaultMaxTimeoutInSec = 30;
            public const string HealthCheckUrl = "/health";
        }

        public static class DataConstants
        {
            public const string MigrationConnectionString = ".;Database=TestDB;Trusted_Connection=True;MultipleActiveResultSets=true";
        }
    }
}
