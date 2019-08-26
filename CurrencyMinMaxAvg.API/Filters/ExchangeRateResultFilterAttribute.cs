using AutoMapper;
using CurrencyMinMaxAvg.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace CurrencyMinMaxAvg.API.Filters
{
    public class ExchangeRatesResultFilterAttribute : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context,
            ResultExecutionDelegate next)
        {
            var resultFromAction = context.Result as ObjectResult;
            if (resultFromAction?.Value == null
                || resultFromAction.StatusCode < 200
                || resultFromAction.StatusCode > 300)
            {
                await next();
                return;
            }

            //Map-transform the result into acceptable (DTO) one
            var mapper = context.HttpContext.RequestServices.GetService<IMapper>();
            resultFromAction.Value = mapper.Map<ExchangeRatesMinMaxAvgDto>(resultFromAction.Value);

            await next();
        }
    }
}
