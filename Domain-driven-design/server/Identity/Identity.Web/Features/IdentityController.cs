namespace PetFoodShop.Identity.Web.Features
{
    using Application.Commands.Common;
    using Application.Commands.Login;
    using Application.Commands.Register;
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Web.Controllers.v1;
    using System.Threading.Tasks;
    using Application.Commands.ChangePassword;
    using Microsoft.AspNetCore.Authorization;

    public class IdentityController : ApiController
    {
        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult<TokenOutputModel>> Register(RegisterCommand command)
            => await this.Send(command);

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginCommand.LoginOutputModel>> Login(LoginCommand command)
            => await this.Send(command);

        [Authorize]
        [HttpPut]
        [Route(nameof(ChangePassword))]
        public async Task<ActionResult> ChangePassword(ChangePasswordCommand command)
            => await this.Send(command);
    }
}
