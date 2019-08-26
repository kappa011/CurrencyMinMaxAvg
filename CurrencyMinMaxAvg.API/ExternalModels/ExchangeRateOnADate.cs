using System.Collections.Generic;

namespace CurrencyMinMaxAvg.API.ExternalModels
{
    public class ExchangeRateOnADate
    {
        public Dictionary<string, decimal> Rates { get; set; }
        public string Base { get; set; }
        public string Date { get; set; }
    }
}
