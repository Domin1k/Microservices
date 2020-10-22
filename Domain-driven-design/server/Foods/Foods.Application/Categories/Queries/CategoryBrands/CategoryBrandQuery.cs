namespace PetFoodShop.Foods.Application.Categories.Queries.CategoryBrands
{
    using Domain.Categories.Models;
    using MediatR;
    using PetFoodShop.Application.Mapping;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class CategoryBrandQuery : IRequest<IEnumerable<CategoryBrandQuery.FoodCategoryBrandOutputModel>>
    {
        public int CategoryId { get; set; }

        public class FoodCategoryBrandOutputModel : IMapFrom<FoodBrand>
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public int CategoryId { get; set; }

            public int TotalFoods { get; set; }
        }

        public class CategoryBrandQueryHandler : IRequestHandler<CategoryBrandQuery, IEnumerable<FoodCategoryBrandOutputModel>>
        {
            private readonly IFoodCategoriesRepository foodCategoriesRepository;
            public CategoryBrandQueryHandler(IFoodCategoriesRepository foodCategoriesRepository) => this.foodCategoriesRepository = foodCategoriesRepository;

            public async Task<IEnumerable<FoodCategoryBrandOutputModel>> Handle(
                CategoryBrandQuery request,
                CancellationToken cancellationToken)
                => await this.foodCategoriesRepository.FindCategoryBrands(request.CategoryId, cancellationToken);
        }
    }
}
