using Newtonsoft.Json;

namespace ExchangeRatesApi.Models.TcmbModels
{
    public class Item
    {
        [JsonProperty("Tarih")]
        public string Tarih { get; set; }

        [JsonProperty("TP_DK_USD_S_YTL")]
        public string? USD { get; set; }

        [JsonProperty("TP_DK_EUR_S_YTL")]
        public string? EUR { get; set; }

        [JsonProperty("UNIXTIME")]
        public UnixTime UnixTime { get; set; }

    }
}
