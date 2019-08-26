using CurrencyMinMaxAvg.API.ExternalModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyMinMaxAvg.API.Services
{
    public interface ICallExternalApiService
    {
        //Task<ExchangeRateOnADate> GetExchangeRateOnADateAsync(
        //    string baseCurrency, string targetCurrency, string date);
        Task<IEnumerable<ExchangeRateOnADate>> GetExchangeRatesOnDatesAsync(
            string baseCurrency, string targetCurrency, IEnumerable<string> dates);
    }
}
