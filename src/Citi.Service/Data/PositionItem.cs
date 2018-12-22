using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Citi.Service.Data
{
    public class PositionItem
    {
        [JsonProperty("id")]
        public int PositionId { get; set; }

        [JsonProperty("sbl")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Symbol Symbol { get; set; }

        [JsonProperty("q")]
        public int Quantity { get; set; }

        [JsonProperty("spt")]
        public string Spot { get; set; }

        [JsonProperty("pos")]
        public string Position { get; set; }

        [JsonProperty("dlt")]
        public string Delta { get; set; }

        public void UpdateSpot(double spot)
        {
            Spot = spot.ToString("0.##");
            Position = (spot * Quantity).ToString("0.##");
            Delta = (spot * Quantity * 0.01).ToString("0.##");
        }
    }
}