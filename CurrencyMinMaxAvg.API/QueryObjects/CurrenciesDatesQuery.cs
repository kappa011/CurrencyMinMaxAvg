using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CurrencyMinMaxAvg.API.CustomAttributes;
using CurrencyMinMaxAvg.API.CustomModelBinders;
using CurrencyMinMaxAvg.API.Enumerators;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyMinMaxAvg.API.QueryObjects
{
    public class CurrenciesDatesQuery
    {
        [FromRoute]
        //[ValidEnumValue]
        public CurrenciesEnum BaseCurrency { get; set; }

        [FromRoute]
        //[ValidEnumValue]
        public CurrenciesEnum TargetCurrency { get; set; }

        [FromQuery]
        [Required]
        [ModelBinder(BinderType = typeof(ArrayModelBinder))]
        public IEnumerable<string> Dates { get; set; }
    }
}
