namespace PetFoodShop.Foods.Application.Foods.Commands.EditPrice
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Common;
    using MediatR;

    public class EditPriceCommand : IRequest<FoodDetailModelOutputModel>
    {
        public int FoodId { get; set; }

        public decimal Price { get; set; }

        public class EditPriceCommandHandler : IRequestHandler<EditPriceCommand, FoodDetailModelOutputModel>
        {
            private readonly IFoodsRepository foodsRepository;
            private readonly IMapper mapper;
            public EditPriceCommandHandler(IFoodsRepository foodsRepository, IMapper mapper)
            {
                this.foodsRepository = foodsRepository;
                this.mapper = mapper;
            }

            public async Task<FoodDetailModelOutputModel> Handle(EditPriceCommand request, CancellationToken cancellationToken)
            {
                var food = await this.foodsRepository.Find(request.FoodId, cancellationToken);

                food.UpdatePrice(request.Price);

                await this.foodsRepository.Save(food, cancellationToken);

                return this.mapper.Map<FoodDetailModelOutputModel>(food);
            }
        }
    }
}
