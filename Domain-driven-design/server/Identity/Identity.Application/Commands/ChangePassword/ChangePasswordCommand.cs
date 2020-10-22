namespace PetFoodShop.Identity.Application.Commands.ChangePassword
{
    using Common;
    using Contracts;
    using MediatR;
    using PetFoodShop.Application;
    using PetFoodShop.Application.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    public class ChangePasswordCommand : ChangePasswordInputModel, IRequest<Result>
    {
        public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Result>
        {
            private readonly IIdentityService identity;
            private readonly ICurrentUserService currentUserService;

            public ChangePasswordCommandHandler(IIdentityService identity, ICurrentUserService currentUserService)
            {
                this.identity = identity;
                this.currentUserService = currentUserService;
            }

            public async Task<Result> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
                => await this.identity.ChangePassword(this.currentUserService.UserId.ToString(), request);
        }
    }
}
