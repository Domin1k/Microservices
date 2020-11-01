namespace PetFoodShop.Identity.Startup.Specs
{
    using Application.Commands.Login;
    using Application.Commands.Register;
    using FluentAssertions;
    using Infrastructure;
    using MyTested.AspNetCore.Mvc;
    using PetFoodShop.Web.Controllers;
    using Web.Features;
    using Xunit;

    public class IdentityControllerSpecs
    {
        [Fact]
        public void Register_ShouldHaveCorrectAttributes()
            => MyController<IdentityController>
                .Calling(c => c
                    .Register(RegisterCommandFakes.Data.GetCommand()))
                .ShouldHave()
                .ActionAttributes(attr => attr
                    .RestrictingForHttpMethod(HttpMethod.Post)
                    .SpecifyingRoute(nameof(IdentityController.Register)));

        [Theory]
        [InlineData(RegisterCommandFakes.TestEmail, RegisterCommandFakes.ValidPassword)]
        public void Login_ShouldHaveCorrectAttributes(string email, string password)
            => MyController<IdentityController>
                .Calling(c => c
                    .Login(new LoginCommand
                    {
                        Email = email,
                        Password = password
                    }))
                .ShouldHave()
                .ActionAttributes(attr => attr
                    .RestrictingForHttpMethod(HttpMethod.Post)
                    .SpecifyingRoute(nameof(IdentityController.Login)));

        [Theory]
        [InlineData(RegisterCommandFakes.TestEmail, RegisterCommandFakes.ValidPassword, TokenGeneratorFakes.ValidToken)]
        public void Login_ShouldReturnTokenWhenUserEntersValidCredentials(string email, string password, string token)
            => MyPipeline
                .Configuration()
                .ShouldMap(request => request
                    .WithLocation($"{ControllerConstants.RouteV1}/Identity/Login")
                    .WithMethod(HttpMethod.Post)
                    .WithJsonBody(new
                    {
                        Email = email,
                        Password = password
                    }))
                .To<IdentityController>(c => c
                    .Login(new LoginCommand
                    {
                        Email = email,
                        Password = password
                    }))
                .Which()
                .ShouldReturn()
                .ActionResult<LoginCommand.LoginOutputModel>(result => result
                    .Passing(model => model.Token.Should().Be(token)));
    }
}
