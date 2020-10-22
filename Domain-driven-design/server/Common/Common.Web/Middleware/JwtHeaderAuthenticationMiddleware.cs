namespace PetFoodShop.Web.Middleware
{
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Contracts;
    using Microsoft.AspNetCore.Http;

    public class JwtHeaderAuthenticationMiddleware : IMiddleware
    {
        private readonly ICurrentTokenService currentToken;

        public JwtHeaderAuthenticationMiddleware(ICurrentTokenService currentToken)
        {
            this.currentToken = currentToken;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var token = context.Request.Headers[WebConstants.AuthConstants.AuthorizationHeaderName].ToString();

            if (!string.IsNullOrWhiteSpace(token))
            {
                this.currentToken.Set(token.Split().Last());
            }

            await next.Invoke(context);
        }
    }
}
