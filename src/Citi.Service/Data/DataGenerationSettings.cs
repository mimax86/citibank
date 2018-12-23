namespace Citi.Service.Data
{
    public class DataGenerationSettings
    {
        /// <summary>
        /// Guarantees that price can only asymptotically approach 0.01, but never reach 0 value
        /// </summary>
        public decimal MinimumPrice { get; set; } = 0.01m;

        /// <summary>
        /// Allows initial price to be within the range from 0.01 to 1000.01
        /// </summary>
        public decimal PriceRange { get; set; } = 1000m;

        /// <summary>
        /// Allows price to fluctuate within the range -50% to +50% of previous price value
        /// </summary>
        public decimal PriceFluctuation { get; set; } = 0.5m;

        /// <summary>
        /// Sets timer interval in milliseconds for positions update
        /// </summary>
        public int UpdateInterval { get; set; } = 1000;

        /// <summary>
        /// The number of generated position items
        /// </summary>
        public int PositionsCount { get; set; } = 10000;

        /// <summary>
        /// Minimum position quatity for initial generation
        /// </summary>
        public int MinimumQuantity { get; set; } = 1;

        /// <summary>
        /// Maximum position quatity for initial generation
        /// </summary>
        public int MaximumQuantity { get; set; } = 1000;
    }
}