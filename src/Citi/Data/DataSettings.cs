namespace Citi.Data
{
    public class DataSettings
    {
        public int UpdateInterval { get; set; } = 60000;

        public int PositionsCount { get; set; } = 10000;

        public int UpdatePositionsCount { get; set; } = 1000;
    }
}