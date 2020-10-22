namespace PetFoodShop.Domain.Foods.Events
{
    public class BrandCreatedMessage
    {
        public int BrandId { get; set; }

        public string BrandName { get; set; }
    }
}
