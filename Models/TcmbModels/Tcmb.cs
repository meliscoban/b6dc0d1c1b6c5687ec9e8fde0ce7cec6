using Newtonsoft.Json;

namespace ExchangeRatesApi.Models.TcmbModels
{
    public class Tcmb
    {
        [JsonProperty("items")]
        public List<Item> Items { get; set; }

        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }
    }
}