namespace PetFoodShop.Foods.Application.Foods.Queries.Details
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Domain.Foods.Models;
    using MediatR;
    using PetFoodShop.Application.Mapping;

    public class DetailsQuery : IRequest<FoodDetailModelOutputModel>
    {
        public int FoodId { get; set; }

        public class DetailsQueryHandler : IRequestHandler<DetailsQuery, FoodDetailModelOutputModel>
        {
            private readonly IFoodsRepository foodsRepository;

            public DetailsQueryHandler(IFoodsRepository foodsRepository) => this.foodsRepository = foodsRepository;

            public async Task<FoodDetailModelOutputModel> Handle(
                DetailsQuery request,
                CancellationToken cancellationToken)
            {
                var result = await this.foodsRepository.Details(request.FoodId, cancellationToken);
                return result;
            }
        }
    }
}
