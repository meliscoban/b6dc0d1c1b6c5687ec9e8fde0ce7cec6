namespace ExchangeRatesApi.Dtos
{
    public class CurrencyResponse
    {
        public string From { get; set; }

        public string To { get; set; } = "TRY";

        public decimal Amount { get; set; }

        public string Date { get; set; }

        public string Provider { get; set; }
    }
}