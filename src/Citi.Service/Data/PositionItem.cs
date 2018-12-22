using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Citi.Service.Data
{
    public class PositionItem
    {
        [JsonProperty("id")] public int PositionId { get; set; }

        [JsonProperty("sbl")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Symbol Symbol { get; set; }

        [JsonProperty("q")]
        public int Quantity { get; set; }

        [JsonProperty("spt")]
        [JsonConverter(typeof(DecimalConverter), ".")]
        public decimal Spot { get; set; }

        [JsonProperty("pos")]
        [JsonConverter(typeof(DecimalConverter), ",")]
        public decimal Position { get; set; }

        [JsonProperty("dlt")]
        [JsonConverter(typeof(DecimalConverter), ".")]
        public decimal Delta { get; set; }

        public void UpdateSpot(decimal spot)
        {
            Spot = spot;
            var position = spot * Quantity;
            Position = position;
            Delta = position * 0.01m;
        }
    }
}