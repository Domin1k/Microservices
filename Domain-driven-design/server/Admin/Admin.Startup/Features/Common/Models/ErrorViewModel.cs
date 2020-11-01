namespace PetFoodShop.Admin.Startup.Features.Common.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
    }
}
