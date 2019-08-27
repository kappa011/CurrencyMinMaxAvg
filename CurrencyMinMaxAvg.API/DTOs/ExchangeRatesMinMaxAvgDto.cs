using CurrencyMinMaxAvg.API.CustomAttributes;
using CurrencyMinMaxAvg.API.Enumerators;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CurrencyMinMaxAvg.API.DTOs
{
    public class ExchangeRatesMinMaxAvgDto
    {
        [JsonIgnore]
        public CurrenciesEnum BaseCurr { get; set; }
        public string BaseCurrency => BaseCurr.ToString();
        [JsonIgnore]
        public CurrenciesEnum TargetCurr { get; set; }
        public string TargetCurrency => TargetCurr.ToString();
        public MinimumRate MinRate { get; set; }
        public MaximumRate MaxRate { get; set; }
        public decimal AvgRate { get; set; }

        #region For manual "auto" mapper (replaced with Filter and Automapper)
        //public ExchangeRateMinMaxAvg(MinimumRate minRate, MaximumRate maxRate, decimal avgRate)
        //{   
        //    MinRate = minRate;
        //    MaxRate = maxRate;
        //    AvgRate = avgRate;
        //} 
        #endregion

        public class MinimumRate
        {
            public decimal Value { get; set; }
            public string Date { get; set; }

            #region For manual "auto" mapper (replaced with Filter and Automapper)
            //public MinimumRate(string ratesOnDatesMinDate, decimal ratesOnDatesMinVal)
            //{
            //    Date = ratesOnDatesMinDate;
            //    Value = ratesOnDatesMinVal;
            //} 
            #endregion
        }

        public class MaximumRate
        {
            public decimal Value { get; set; }
            public string Date { get; set; }

            #region For manual "auto" mapper (replaced with Filter and Automapper)
            //public MaximumRate(string ratesOnDatesMaxDate, decimal ratesOnDatesMaxVal)
            //{
            //    Date = ratesOnDatesMaxDate;
            //    Value = ratesOnDatesMaxVal;
            //} 
            #endregion
        }
    }
}
