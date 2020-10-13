namespace PetFoodShop.Cart.Services.Models
{
    using AutoMapper;
    using PetFoodShop.Cart.Controllers.Models;
    using PetFoodShop.Models;

    public class CartItemModel : IMapFrom<CartDetailsModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public void Mapping(Profile mapper)
        {
            mapper.CreateMap<CartDetailsModel, CartItemModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(x => x.Quantity, opt => opt.MapFrom(src => src.ProductQuantity));
        }
    }
}
