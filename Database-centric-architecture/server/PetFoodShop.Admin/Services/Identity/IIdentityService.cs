﻿namespace PetFoodShop.Admin.Services.Identity
{
    using System.Threading.Tasks;
    using Models.Identity;
    using Refit;

    public interface IIdentityService
    {
        [Post("/api/v1/Identity/Login")]
        Task<UserOutputModel> Login([Body] UserInputModel loginInput);
    }
}
