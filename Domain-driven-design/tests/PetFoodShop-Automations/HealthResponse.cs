namespace PetFoodShopAutomations
{
    public class HealthResponse
    {
        public string Status { get; set; }

        public HealthResponseEntry Entries { get; set; }
    }

    public class HealthResponseEntry
    {
        public HealthResponseEntryData Sqlserver { get; set; }
    }

    public class HealthResponseEntryData
    {
        public string Status { get; set; }
    }
}
