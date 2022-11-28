using Newtonsoft.Json;

namespace ExchangeRatesApi.Models.TcmbModels
{
    public class UnixTime
    {
        [JsonProperty("$numberLong")]
        public string NumberLong { get; set; }
    }
}