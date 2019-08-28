using CurrencyMinMaxAvg.API.CustomModelBinders;
using CurrencyMinMaxAvg.API.Enumerators;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public IEnumerable<DateTime> Dates { get; set; }
    }
}
