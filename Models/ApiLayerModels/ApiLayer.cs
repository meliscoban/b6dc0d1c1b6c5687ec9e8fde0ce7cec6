using Newtonsoft.Json;

namespace ExchangeRatesApi.Models.ApiLayerModels
{
    public class ApiLayer
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("query")]
        public Query Query { get; set; }

        [JsonProperty("info")]
        public Info Info { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("historical")]
        public bool Historical { get; set; }

        [JsonProperty("result")]
        public decimal Result { get; set; }
    }
}