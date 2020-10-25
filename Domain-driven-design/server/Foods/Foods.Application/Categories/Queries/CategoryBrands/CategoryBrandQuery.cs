namespace PetFoodShop.Foods.Application.Categories.Queries.CategoryBrands
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CategoryBrandQuery : IRequest<FoodCategoryBrandOutputModel>
    {
        public int Id { get; set; }

        public class CategoryBrandQueryHandler : IRequestHandler<CategoryBrandQuery, FoodCategoryBrandOutputModel>
        {
            private readonly IFoodCategoriesRepository foodCategoriesRepository;
            public CategoryBrandQueryHandler(IFoodCategoriesRepository foodCategoriesRepository) => this.foodCategoriesRepository = foodCategoriesRepository;

            public async Task<FoodCategoryBrandOutputModel> Handle(CategoryBrandQuery request, CancellationToken cancellationToken)
                => await this.foodCategoriesRepository.FindCategoryBrands(request.Id, cancellationToken);
        }
    }
}
