namespace PetFoodShop.Identity.Application.Commands.Login
{
    using Common;
    using Contracts;
    using Domain.Models;
    using FluentValidation;
    using MediatR;
    using PetFoodShop.Application;
    using System.Threading;
    using System.Threading.Tasks;

    public class LoginCommand : UserInputModel, IRequest<Result<LoginCommand.LoginOutputModel>>
    {
        public class LoginOutputModel : TokenOutputModel
        {
            public LoginOutputModel(string userId, string token)
                : base(token)
            {
                this.UserId = userId;
            }

            public string UserId { get; }
        }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginOutputModel>>
        {
            private readonly IIdentityService identity;

            public LoginCommandHandler(IIdentityService identity) => this.identity = identity;

            public async Task<Result<LoginOutputModel>> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                var result = await this.identity.Login(request);

                if (!result.Succeeded)
                {
                    return result.Errors;
                }

                return new LoginOutputModel(result.Data.UserId, result.Data.Token);
            }
        }

        public class LoginCommandValidator : AbstractValidator<LoginCommand>
        {
            public LoginCommandValidator()
            {
                this.RuleFor(u => u.Email)
                   .MinimumLength(ModelConstants.Common.MinEmailLength)
                   .MaximumLength(ModelConstants.Common.MaxEmailLength)
                   .EmailAddress()
                   .NotEmpty();

                this.RuleFor(u => u.Password)
                    .MinimumLength(ModelConstants.Common.MinNameLength)
                    .MaximumLength(ModelConstants.Common.MaxNameLength)
                    .NotEmpty();
            }
        }
    }
}
