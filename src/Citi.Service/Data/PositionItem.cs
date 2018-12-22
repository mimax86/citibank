using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Citi.Service.Data
{
    public class PositionItem
    {
        [JsonProperty("positionId")] public int PositionId { get; set; }

        [JsonProperty("symbol")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Symbol Symbol { get; set; }

        [JsonProperty("quantity")] public int Quantity { get; set; }
        [JsonProperty("spot")] public string Spot { get; set; }
        [JsonProperty("position")] public string Position { get; set; }
        [JsonProperty("delta")] public string Delta { get; set; }

        public void UpdateSpot(double spot)
        {
            Spot = spot.ToString("0.##");
            Position = (spot * Quantity).ToString("0.##");
            Delta = (spot * Quantity * 0.01).ToString("0.##");
        }
    }
}