namespace PetFoodShop.Admin.Startup.Middlewares
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Contracts;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using static Web.WebConstants.AuthConstants;

    public class JwtCookieAuthenticationMiddleware : IMiddleware
    {
        private readonly ICurrentTokenService currentTokenService;

        public JwtCookieAuthenticationMiddleware(ICurrentTokenService  currentTokenService)
        {
            this.currentTokenService = currentTokenService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var token = context.Request.Cookies[AuthenticationCookieName];
            if (token != null)
            {
                this.currentTokenService.Set(token);
                context.Request.Headers.Add(AuthorizationHeaderName, $"{AuthorizationHeaderValuePrefix} {token}");
            }

            await next.Invoke(context);
        }
    }

    public static class JwtCookieAuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseJwtCookieAuthentication(this IApplicationBuilder app)
            => app
                .UseMiddleware<JwtCookieAuthenticationMiddleware>()
                .UseAuthentication();
    }
}
