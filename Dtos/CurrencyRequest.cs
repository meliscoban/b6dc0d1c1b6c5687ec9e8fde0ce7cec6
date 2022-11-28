namespace ExchangeRatesApi.Dtos
{
    public class CurrencyRequest
    {
        public string From { get; set; }

        public string Day { get; set; } = DateTime.Now.ToString("dd");

        public string Month { get; set; } = DateTime.Now.ToString("MM");

        public string Year { get; set; } = DateTime.Now.ToString("yyyy");

        public string? ApiKey { get; set; }
    }
}