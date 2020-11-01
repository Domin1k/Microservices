namespace PetFoodShop.Identity.Infrastructure
{
    using System.Collections.Generic;
    using Application.Contracts;
    using FakeItEasy;
    using Persistence.Models;

    public class TokenGeneratorFakes
    {
        public const string ValidToken = "ValidToken";

        public static ITokenGeneratorService FakeTokenGenerator
        {
            get
            {
                var jwtTokenGenerator = A.Fake<ITokenGeneratorService>();

                A.CallTo(() => jwtTokenGenerator.GenerateToken(A<User>.Ignored, A< IEnumerable<string>>.Ignored)).Returns(ValidToken);

                return jwtTokenGenerator;
            }
        }
    }
}
