namespace PetFoodShop.Identity.Application.Commands.Register
{
    using Bogus;

    public class RegisterCommandFakes
    {
        public const string TestEmail = "test@test.com";
        public const string ValidPassword = "TestPass123";

        public static class Data
        {
            public static RegisterCommand GetCommand()
                => new Faker<RegisterCommand>()
                    .RuleFor(u => u.Email, TestEmail)
                    .RuleFor(u => u.Password, ValidPassword)
                    .Generate();
        }
    }
}
