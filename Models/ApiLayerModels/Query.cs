using Newtonsoft.Json;

namespace ExchangeRatesApi.Models.ApiLayerModels
{
    public class Query
    {
        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }
}
