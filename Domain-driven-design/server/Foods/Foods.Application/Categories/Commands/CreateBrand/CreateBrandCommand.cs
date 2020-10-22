namespace PetFoodShop.Foods.Application.Categories.Commands.CreateBrand
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using PetFoodShop.Application;

    public class CreateBrandCommand : IRequest<Result>
    {
        public string Name { get; set; }

        public int FoodCategoryId { get; set; }

        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, Result>
        {
            private readonly IFoodCategoriesRepository repository;

            public CreateBrandCommandHandler(IFoodCategoriesRepository repository) => this.repository = repository;

            public async Task<Result> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                var category = await this.repository.Find(request.FoodCategoryId, cancellationToken);
                category.AddBrand(request.Name);
                await this.repository.Save(category, cancellationToken);

                return Result.Success;
            }
        }
    }
}
