namespace PetFoodShop.Domain.Exceptions
{
    public class InvalidMessageException : BaseDomainException
    {
        public InvalidMessageException()
        {
        }

        public InvalidMessageException(string error) => this.Error = error;
    }
}
