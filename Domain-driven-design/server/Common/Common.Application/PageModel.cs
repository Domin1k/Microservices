namespace PetFoodShop.Application
{
    public abstract class PageModel
    {
        public const int RecordsPerPage = 10;

        public string SortBy { get; set; }

        public string Order { get; set; } = SortOrder<PageModel>.Ascending;

        public int Page { get; set; } = 1;
    }
}
