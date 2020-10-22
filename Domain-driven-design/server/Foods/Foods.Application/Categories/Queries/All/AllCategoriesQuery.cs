namespace PetFoodShop.Foods.Application.Categories.Queries.All
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Categories.Models;
    using MediatR;
    using PetFoodShop.Application.Mapping;

    public class AllCategoriesQuery : IRequest<IEnumerable<AllCategoriesQuery.AllCategoryOutputModel>>
    {
        public class AllCategoryOutputModel : IMapFrom<FoodCategory>
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }

        public class AllCategoriesQueryHandler : IRequestHandler<AllCategoriesQuery, IEnumerable<AllCategoryOutputModel>>
        {
            private readonly IFoodCategoriesRepository foodCategoriesRepository;

            public AllCategoriesQueryHandler(IFoodCategoriesRepository foodCategoriesRepository)
                => this.foodCategoriesRepository = foodCategoriesRepository;

            public async Task<IEnumerable<AllCategoryOutputModel>> Handle(
                AllCategoriesQuery request,
                CancellationToken cancellationToken)
                => await this.foodCategoriesRepository.All(cancellationToken);
        }
    }
}
