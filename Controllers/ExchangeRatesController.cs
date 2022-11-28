using ExchangeRatesApi.Dtos;
using ExchangeRatesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRatesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRatesController : ControllerBase
    {
        [HttpPost]
        [Route("/get-lowest-currency")]
        public CurrencyResponse GetCurrency([FromBody] CurrencyRequest request)
        {
            return ApiRequestBuilderService.GetLowestCurrency(request);
        }
    }
}
