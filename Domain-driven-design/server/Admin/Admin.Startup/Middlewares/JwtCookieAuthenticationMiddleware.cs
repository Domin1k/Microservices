namespace Admin.Startup.Middlewares
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using PetFoodShop.Application.Contracts;
    using static PetFoodShop.Web.WebConstants.AuthConstants;

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
