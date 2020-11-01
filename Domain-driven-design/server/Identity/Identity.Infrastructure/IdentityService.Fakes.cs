namespace PetFoodShop.Identity.Infrastructure
{
    using Application.Commands.Register;
    using FakeItEasy;
    using Microsoft.AspNetCore.Identity;
    using Persistence.Models;

    public class IdentityFakes
    {
        public static UserManager<User> FakeUserManager
        {
            get
            {
                var userManager = A.Fake<UserManager<User>>();

                A.CallTo(
                    () => userManager
                            .FindByEmailAsync(RegisterCommandFakes.TestEmail))
                            .Returns(new User() { Id = "test" , Email = RegisterCommandFakes.TestEmail });

                A
                    .CallTo(
                        () => userManager
                                .CheckPasswordAsync(A<User>.That.Matches(u => u.Email == RegisterCommandFakes.TestEmail), RegisterCommandFakes.ValidPassword))
                    .Returns(true);

                return userManager;
            }
        }
    }
}
