namespace Citi.Service.Data
{
    public class DataGenerationSettings
    {
        public decimal MinimumPrice { get; set; } = 0.01m;

        public decimal PriceRange { get; set; } = 1000m;

        public decimal PriceFluctuation { get; set; } = 0.5m;

        public int UpdateInterval { get; set; } = 1000;

        public int PositionsCount { get; set; } = 10000;

        public int MinimumQuantity { get; set; } = 1;

        public int MaximumQuantity { get; set; } = 1000;
    }
}