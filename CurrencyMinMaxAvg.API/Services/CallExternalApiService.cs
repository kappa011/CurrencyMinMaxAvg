using CurrencyMinMaxAvg.API.ExternalModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CurrencyMinMaxAvg.API.Services
{
    public class CallExternalApiService : ICallExternalApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CallExternalApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? 
                                 throw new ArgumentNullException(nameof(httpClientFactory));
        }
        //public async Task<ExchangeRateOnADate> GetExchangeRateOnADateAsync(
        //    string baseCurrency, string targetCurrency, string date)
        //{
        //    var httpClient = _httpClientFactory.CreateClient();
        //    var response = await httpClient
        //        .GetAsync($"https://api.exchangeratesapi.io/{date}?base={baseCurrency}&symbols={targetCurrency}");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return JsonConvert.DeserializeObject<ExchangeRateOnADate>(
        //            await response.Content.ReadAsStringAsync());
        //    }
        //    return null;
        //}

        public async Task<IEnumerable<ExchangeRateOnADate>> GetExchangeRatesOnDatesAsync(string baseCurrency,
            string targetCurrency, IEnumerable<string> dates)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var singleDateUrls = dates.Select(date =>
                $"https://api.exchangeratesapi.io/{date}?base={baseCurrency}&symbols={targetCurrency}")
                .ToList();

            //Create tasks query
            var getRatesOnDatesTasksQuery =
                from singleDateUrl in singleDateUrls
                select GetRateOnDateAsync(httpClient, singleDateUrl);

            //Run tasks
            var getRatesOnDatesTasks = getRatesOnDatesTasksQuery.ToList();

            return await Task.WhenAll(getRatesOnDatesTasks);
        }

        private async Task<ExchangeRateOnADate> GetRateOnDateAsync(
            HttpClient httpClient, string singleDateUrl)
        {
            var response = await httpClient.GetAsync(singleDateUrl);

            if (!response.IsSuccessStatusCode) return null;
            var rateOnDate = JsonConvert.DeserializeObject<ExchangeRateOnADate>(
                await response.Content.ReadAsStringAsync());
            
            return rateOnDate;
        }
    }
}
