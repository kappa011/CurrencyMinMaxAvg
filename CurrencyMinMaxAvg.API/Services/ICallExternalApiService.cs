using System;
using CurrencyMinMaxAvg.API.ExternalModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyMinMaxAvg.API.Enumerators;

namespace CurrencyMinMaxAvg.API.Services
{
    public interface ICallExternalApiService
    {
        //Task<ExchangeRateOnADate> GetExchangeRateOnADateAsync(
        //    string baseCurrency, string targetCurrency, string date);
        Task<IEnumerable<ExchangeRateOnADate>> GetExchangeRatesOnDatesAsync(
            CurrenciesEnum baseCurrency, CurrenciesEnum targetCurrency, IEnumerable<DateTime> dates);
    }
}
