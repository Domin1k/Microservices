﻿namespace PetFoodShop.Admin.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Admin.Services.Identity;
    using PetFoodShop.Admin.Services.Models.Identity;
    using PetFoodShop.Infrastructure;
    using System;
    using System.Threading.Tasks;
    using static PetFoodShop.Infrastructure.InfrastructureConstants.AuthConstants;

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
        public IActionResult Login() => View(nameof(Login));

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginFormModel model)
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
                            MaxAge = TimeSpan.FromDays(1)
                        });
                },
                success: RedirectToAction(nameof(HomeController.Index), "Home"),
                failure: View("../Home/Index", model));

        [AuthorizeAdministrator]
        public IActionResult Logout()
        {
            this.Response.Cookies.Delete(AuthenticationCookieName);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
