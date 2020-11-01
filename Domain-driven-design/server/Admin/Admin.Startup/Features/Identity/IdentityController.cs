namespace PetFoodShop.Admin.Startup.Features.Identity
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Admin;
    using AutoMapper;
    using Common;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Web;
    using static Web.WebConstants.AuthConstants;

    public class IdentityController : AdministrationController
    {
        private readonly IIdentityService identityService;
        private readonly IMapper mapper;

        public IdentityController(IIdentityService identityService, IMapper mapper)
        {
            this.identityService = identityService;
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login() => this.View();

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginCommandInputModel model)
            => await this.Handle(
                async () =>
                {
                    var result = await this.identityService
                        .Login(this.mapper.Map<UserInputModel>(model));

                    this.Response.Cookies.Append(
                        AuthenticationCookieName,
                        result.Token,
                        new CookieOptions
                        {
                            HttpOnly = true,
                            Secure = false,
                            MaxAge = TimeSpan.FromDays(10)
                        });
                },
                success: this.RedirectToAction(nameof(HomeController.Index), "Home"),
                failure: this.View( model));

        // [AuthorizeAdministrator]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Logout()
        {
            this.Response.Cookies.Delete(AuthenticationCookieName);

            return this.RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
