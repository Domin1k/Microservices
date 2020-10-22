namespace PetFoodShop.Identity.Application.Contracts
{
    public interface IApplicationUser
    {
        string Id { get; set; }
        
        string Email { get; set; }
    }
}
