namespace PetFoodShop.Infrastructure
{
    public static class InfrastructureConstants
    {
        public static class ConfigurationConstants
        {
            public const string DefaultConnectionString = "DefaultConnection";
            public const int DefaultMaxRetryCount = 10;
            public const int DefaultMaxTimeoutInSec = 30;
        }

        public static class AuthConstants
        {
            public const string AuthenticationCookieName = "Authentication";
            public const string AuthorizationHeaderName = "Authorization";
            public const string AuthorizationHeaderValuePrefix = "Bearer";
            public const string AdministratorRoleName = "Administrator";
        }

        public static class SwaggerConstants
        {
            public const string SwaggerEndpoint = "/swagger/v1/swagger.json";
            public const string SwaggerName = "PetFoodShop API";
        }
    }
}
