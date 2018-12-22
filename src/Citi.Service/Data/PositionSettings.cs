namespace Citi.Service.Data
{
    public class PositionSettings
    {
        public int UpdateInterval { get; set; } = 1000;

        public int PositionsCount { get; set; } = 10000;

        public int UpdatePositionsCount { get; set; } = 1000;
    }
}