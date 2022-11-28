using Newtonsoft.Json;

namespace ExchangeRatesApi.Models.ApiLayerModels
{
    public class Info
    {
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("rate")]
        public decimal Rate { get; set; }
    }
}
