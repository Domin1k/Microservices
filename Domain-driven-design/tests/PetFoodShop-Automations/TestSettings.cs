namespace PetFoodShopAutomations
{
    public class TestSettings
    {
        public TestEnvironmentType Environment { get; set; }
    }

    public class TestEnvironmentType
    {
        public TestEnvironment Development { get; set; }
        
        public TestEnvironment Production { get; set; }
    }

    public class TestEnvironment
    {
        public TestClientEndpoint Clients { get; set; }

        public TestServiceEndpoint Services { get; set; }
    }

    public class TestClientEndpoint
    {
        public string UserClientUrl { get; set; }
    }

    public class TestServiceEndpoint
    {
        public string FoodsServiceUrl { get; set; }

        public string CartServiceUrl { get; set; }

        public string IdentityServiceUrl { get; set; }
    }
}
