namespace PetFoodShopAutomations
{
    using Flurl.Http;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Xunit;

    public class HealthCheckTest
    {
        private const string FileSettingsName = "endpointsettings.json";
        private const string Healthy = "Healthy";
        private readonly TestEnvironment _environment;

        public HealthCheckTest()
        {
            var filePath = $"{Directory.GetCurrentDirectory()}\\{FileSettingsName}";
            var settings = JsonConvert.DeserializeObject<TestSettings>(File.ReadAllText(filePath));

            this._environment = Environment.GetEnvironmentVariable("Environment") 
                switch
                {
                    "Development" => settings.Environment.Development,
                    "Production" => settings.Environment.Production,
                    _ => throw new ArgumentException($"{Environment.GetEnvironmentVariable("Environment")} is not valid environment type!")
                };
        }

        [Fact]
        public async Task AllClients_ShouldReturn200OK()
        {
            var url = await this._environment.Clients.UserClientUrl.GetAsync();
            url.StatusCode.Should().Be((int) HttpStatusCode.OK);
        }

        [Fact]
        public async Task AllMicroServicesHealthChecks_ShouldReturn200OkWithStatusHealthy()
        {
            //var foodsServiceResponse = await $"{this._environment.Services.FoodsServiceUrl}/health".GetJsonAsync<HealthResponse>();
            var cartServiceResponse = await $"{this._environment.Services.CartServiceUrl}/health".GetJsonAsync<HealthResponse>();
            var identityServiceResponse = await $"{this._environment.Services.IdentityServiceUrl}/health".GetJsonAsync<HealthResponse>();

            //foodsServiceResponse.Should().NotBeNull();
            //foodsServiceResponse.Status.Should().NotBeNull();
            //foodsServiceResponse.Entries.Should().NotBeNull();
            //foodsServiceResponse.Entries.Sqlserver.Should().NotBeNull();
            //foodsServiceResponse.Entries.Sqlserver.Status.Should().NotBeNull();
            //foodsServiceResponse.Status.Should().Be(Healthy);
            //foodsServiceResponse.Entries.Sqlserver.Status.Should().Be(Healthy);

            cartServiceResponse.Should().NotBeNull();
            cartServiceResponse.Status.Should().NotBeNull();
            cartServiceResponse.Entries.Should().NotBeNull();
            cartServiceResponse.Entries.Sqlserver.Should().NotBeNull();
            cartServiceResponse.Entries.Sqlserver.Status.Should().NotBeNull();
            cartServiceResponse.Status.Should().Be(Healthy);
            cartServiceResponse.Entries.Sqlserver.Status.Should().Be(Healthy);

            identityServiceResponse.Should().NotBeNull();
            identityServiceResponse.Status.Should().NotBeNull();
            identityServiceResponse.Entries.Should().NotBeNull();
            identityServiceResponse.Entries.Sqlserver.Should().NotBeNull();
            identityServiceResponse.Entries.Sqlserver.Status.Should().NotBeNull();
            identityServiceResponse.Status.Should().Be(Healthy);
            identityServiceResponse.Entries.Sqlserver.Status.Should().Be(Healthy);
        }
    }
}
