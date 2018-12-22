using System;
using System.Globalization;
using Newtonsoft.Json;

namespace Citi.Service.Data
{
    public class DecimalConverter : JsonConverter<decimal>
    {
        private readonly NumberFormatInfo _formatInfo;

        public DecimalConverter(string separator = null)
        {
            _formatInfo = new NumberFormatInfo {NumberDecimalSeparator = separator ?? ","};
        }

        public override void WriteJson(JsonWriter writer, decimal value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString("0.##", _formatInfo));
        }

        public override decimal ReadJson(JsonReader reader, Type objectType, decimal existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}