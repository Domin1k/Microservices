namespace PetFoodShop.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using PetFoodShop.Services;
    using Polly;
    using System;
    using System.Net;
    using System.Net.Http.Headers;
    using static InfrastructureConstants;

    public static class HttpClientBuilderExtensions
    {
        public static void WithConfiguration(this IHttpClientBuilder httpClientBuilder, string baseAddress)
            => httpClientBuilder
                .ConfigureHttpClient((serviceProvider, client) =>
                {
                    client.BaseAddress = new Uri(baseAddress);

                    var requestServices = serviceProvider
                        .GetService<IHttpContextAccessor>()
                        ?.HttpContext
                        .RequestServices;

                    var currentToken = requestServices
                        ?.GetService<ICurrentTokenService>()
                        ?.Get();

                    if (currentToken == null)
                    {
                        return;
                    }

                    var authorizationHeader = new AuthenticationHeaderValue(AuthConstants.AuthorizationHeaderValuePrefix, currentToken);
                    client.DefaultRequestHeaders.Authorization = authorizationHeader;
                })
                .AddTransientHttpErrorPolicy(policy => policy
                    .OrResult(result => result.StatusCode == HttpStatusCode.NotFound)
                    .WaitAndRetryAsync(6, retry => TimeSpan.FromSeconds(Math.Pow(2, retry))))
                    .AddTransientHttpErrorPolicy(policy => policy.CircuitBreakerAsync(5, TimeSpan.FromSeconds(ConfigurationConstants.DefaultMaxTimeoutInSec)));
    }
}
