using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Citi.Data
{
    public class PositionLevelRisk
    {
        [JsonProperty("positionId")] public int PositionId { get; set; }
        [JsonProperty("symbol")] public Symbol Symbol { get; set; }
        [JsonProperty("quantity")] public double Quantity { get; set; }
        [JsonProperty("spot")] public double Spot { get; set; }
        [JsonProperty("position")] public double Position { get; set; }
        [JsonProperty("delta")] public double Delta { get; set; }

        public void UpdateSpot(double spot)
        {
            Spot = spot;
            Position = spot * Quantity;
            Delta = Position * 0.01;
        }
    }
}