namespace PetFoodShop.Application.Contracts
{
    public interface ICurrentTokenService
    {
        string Get();

        void Set(string token);
    }
}
