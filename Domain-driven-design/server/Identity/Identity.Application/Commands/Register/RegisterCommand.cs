namespace PetFoodShop.Identity.Application.Commands.Register
{
    using Common;
    using Contracts;
    using Domain.Models;
    using FluentValidation;
    using MediatR;
    using PetFoodShop.Application;
    using System.Threading;
    using System.Threading.Tasks;

    public class RegisterCommand : UserInputModel, IRequest<Result<TokenOutputModel>>
    {
        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<TokenOutputModel>>
        {
            private readonly IIdentityService identity;

            public RegisterCommandHandler(IIdentityService identity) => this.identity = identity;

            public async Task<Result<TokenOutputModel>> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                var result = await this.identity.Register(request);
                return !result.Succeeded 
                    ? Result<TokenOutputModel>.Failure(result.Errors) 
                    : new TokenOutputModel(result.Data.Token);
            }
        }

        public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
        {
            public RegisterCommandValidator()
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
