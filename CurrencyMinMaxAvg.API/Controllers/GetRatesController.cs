using CurrencyMinMaxAvg.API.ExternalModels;
using CurrencyMinMaxAvg.API.Filters;
using CurrencyMinMaxAvg.API.QueryObjects;
using CurrencyMinMaxAvg.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using CurrencyMinMaxAvg.API.DTOs;

namespace CurrencyMinMaxAvg.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetRatesController : ControllerBase
    {
        private readonly ICallExternalApiService _iCallExternalApiService;

        public GetRatesController(ICallExternalApiService iCallExternalApiService)
        {
            _iCallExternalApiService = iCallExternalApiService ??
                                       throw new ArgumentNullException(nameof(iCallExternalApiService));
        }

        //[HttpGet]
        //public async Task<ExchangeRateOnADate> GetRateOnDate(
        //    [FromQuery] string baseCurrency,
        //    [FromQuery] string targetCurrency,
        //    [FromQuery] string date)
        //{
        //    return await _iCallExternalApiService.GetExchangeRateOnADateAsync(baseCurrency, targetCurrency, date);
        //}

        [HttpGet]
        [ExchangeRatesResultFilter]
        [Route("{baseCurrency}/{targetCurrency}")]
        public async Task<IActionResult> GetRatesOnDates(
            [FromRoute, FromQuery] CurrenciesDatesQuery query)
        {
            var ratesOnDates =
                await _iCallExternalApiService.GetExchangeRatesOnDatesAsync(
                    query.BaseCurrency, query.TargetCurrency, query.Dates);

            var exchangeRatesOnDates = ratesOnDates as ExchangeRateOnADate[] ?? ratesOnDates.ToArray();
            
            return Ok(exchangeRatesOnDates);

            #region For manual "auto" mapper (replaced with Filter and Automapper)
            //var ratesOnDatesMinVal = exchangeRatesOnDates.SelectMany(r => r.Rates.Values).Min();
            //var ratesOnDatesMinDate = exchangeRatesOnDates.Where(r => r.Rates.Values.Min() == ratesOnDatesMinVal).Select(d => d.Date).FirstOrDefault();
            //var ratesOnDatesMaxVal = exchangeRatesOnDates.SelectMany(r => r.Rates.Values).Max();
            //var ratesOnDatesMaxDate = exchangeRatesOnDates.Where(r => r.Rates.Values.Max() == ratesOnDatesMaxVal).Select(d => d.Date).FirstOrDefault();
            //var ratesOnDatesAverage = exchangeRatesOnDates.SelectMany(r => r.Rates.Values).Average();

            //var resultMinMaxAvg = new ExchangeRateMinMaxAvg(
            //    new ExchangeRateMinMaxAvg.MinimumRate(ratesOnDatesMinDate, ratesOnDatesMinVal),
            //    new ExchangeRateMinMaxAvg.MaximumRate(ratesOnDatesMaxDate, ratesOnDatesMaxVal),
            //    ratesOnDatesAverage);

            //return Ok(resultMinMaxAvg); 
            #endregion
        }
    }
}
