namespace PetFoodShop.Foods.Application.Foods.Queries.BrandFoods
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Foods.Models;
    using MediatR;
    using PetFoodShop.Application.Mapping;

    public class BrandFoodsQuery : IRequest<IEnumerable<BrandFoodsQuery.BrandFoodOutputModel>>
    {
        public int BrandId { get; set; }

        public class BrandFoodOutputModel : IMapFrom<Food>
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public decimal Price { get; set; }

            public string Image { get; set; }

            public int FoodBrandId { get; set; }
        }

        public class BrandFoodsQueryHandler : IRequestHandler<BrandFoodsQuery, IEnumerable<BrandFoodOutputModel>>
        {
            private readonly IFoodsRepository foodsRepository;

            public BrandFoodsQueryHandler(IFoodsRepository foodsRepository) => this.foodsRepository = foodsRepository;

            public async Task<IEnumerable<BrandFoodOutputModel>> Handle(BrandFoodsQuery request, CancellationToken cancellationToken)
                => await this.foodsRepository.BrandFoods(request.BrandId, cancellationToken);
        }
    }
}
