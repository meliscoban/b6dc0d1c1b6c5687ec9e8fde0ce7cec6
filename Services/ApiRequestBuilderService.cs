using ExchangeRatesApi.Dtos;
using ExchangeRatesApi.Models.ApiLayerModels;
using ExchangeRatesApi.Models.TcmbModels;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;

namespace ExchangeRatesApi.Services
{
    public static class ApiRequestBuilderService
    {
        private static List<CurrencyResponse> responses;
        private static string provider;

        public static CurrencyResponse GetLowestCurrency(CurrencyRequest currencyRequest)
        {
            responses = new List<CurrencyResponse>();

            GetResponseOfApiLayer(currencyRequest);
            GetResponseOfTcmb(currencyRequest);

            CurrencyResponse response = responses.OrderBy(x => x.Amount).First();

            return response;
        }

        private static void GetResponseOfApiLayer(CurrencyRequest currencyRequest)
        {
            provider = "ApiLayer";

            DateTime date = CheckWeekendDates(currencyRequest);

            StringBuilder sb = new StringBuilder();
            sb.Append("https://api.apilayer.com/exchangerates_data/convert?to=TRY");
            sb.Append("&from=");
            sb.Append(currencyRequest.From);
            sb.Append("&amount=1&date=");
            sb.Append(date.Year);
            sb.Append("-");
            sb.Append(date.Month);
            sb.Append("-");
            sb.Append(date.Day);
            string url = sb.ToString();
            
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("apikey", "yOLP4N8xhqPEi2WwMjRsbcB7kUdo9tcg");
            ApiLayer result = ConvertJsonToObjectFromUrl<ApiLayer>(httpClient, url).Result;

            CurrencyResponse currencyResponse = new CurrencyResponse();
            currencyResponse.Amount = result.Result;
            currencyResponse.From = currencyRequest.From;
            currencyResponse.Date = result.Date;
            currencyResponse.Provider = provider;

            responses.Add(currencyResponse);
        }

        private static void GetResponseOfTcmb(CurrencyRequest currencyRequest)
        {
            provider = "TCMB";

            DateTime date = CheckWeekendDates(currencyRequest);

            StringBuilder sb = new StringBuilder();
            sb.Append("https://evds2.tcmb.gov.tr/service/evds/series=TP.DK.");
            sb.Append(currencyRequest.From);
            sb.Append(".S.YTL&startDate=");
            sb.Append(date.Day);
            sb.Append("-");
            sb.Append(date.Month);
            sb.Append("-");
            sb.Append(date.Year);
            sb.Append("&endDate=");
            sb.Append(date.Day);
            sb.Append("-");
            sb.Append(date.Month);
            sb.Append("-");
            sb.Append(date.Year);
            sb.Append("&type=json&key=");
            sb.Append(currencyRequest.ApiKey);
            sb.ToString();
            string url = sb.ToString();

            HttpClient httpClient = new HttpClient();
            Tcmb result = ConvertJsonToObjectFromUrl<Tcmb>(httpClient, url).Result;

            CurrencyResponse currencyResponse = new CurrencyResponse();
            CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-US");
            if (currencyRequest.From == "USD")
                currencyResponse.Amount = Convert.ToDecimal(result.Items[0].USD, cultureInfo);
            if (currencyRequest.From == "EUR")
                currencyResponse.Amount = Convert.ToDecimal(result.Items[0].EUR, cultureInfo);
            currencyResponse.From = currencyRequest.From;
            currencyResponse.Date = result.Items[0].Tarih;
            currencyResponse.Provider = provider;

            responses.Add(currencyResponse);
        }

        private static DateTime CheckWeekendDates(CurrencyRequest currencyRequest)
        {
            DateTime date = DateTime.Parse(currencyRequest.Day + "-" + currencyRequest.Month + "-" + currencyRequest.Year);

            if (date.DayOfWeek == DayOfWeek.Saturday) 
                date = date.AddDays(-1);
            if (date.DayOfWeek == DayOfWeek.Sunday)
                date = date.AddDays(-2);
            
            return date;
        }

        private static async Task<T> ConvertJsonToObjectFromUrl<T>(HttpClient httpClient, string url)
        {
            HttpResponseMessage response = await httpClient.GetAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(responseContent);

            return result;
        }
    }
}