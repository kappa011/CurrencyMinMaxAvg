using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CurrencyMinMaxAvg.API.DTOs;
using CurrencyMinMaxAvg.API.ExternalModels;

namespace CurrencyMinMaxAvg.API.AutomapperProfiles
{
    public class ExchangeRatesProfile : Profile
    {
        public ExchangeRatesProfile()  
        {
            CreateMap<IEnumerable<ExchangeRateOnADate>, ExchangeRatesMinMaxAvgDto>()
                .ForMember(dest => dest.BaseCurrency, opt => opt.MapFrom(src => src.Select(b => b.Base).First()))
                .ForMember(dest => dest.TargetCurrency, opt => opt.MapFrom(src => src.SelectMany(t => t.Rates.Keys).Min()))
                .ForPath(dest => dest.MinRate.Value,
                    opt => opt.MapFrom(src => src.SelectMany(s => s.Rates.Values).Min()))
                .ForPath(dest => dest.MinRate.Date,
                    opt => opt.MapFrom(src =>
                        src.Where(s => s.Rates.ContainsValue(src.SelectMany(m => m.Rates.Values).Min()))
                            .Select(d => d.Date).First()))
                .ForPath(dest => dest.MaxRate.Value,
                    opt => opt.MapFrom(src => src.SelectMany(s => s.Rates.Values).Max()))
                .ForPath(dest => dest.MaxRate.Date,
                    opt => opt.MapFrom(src =>
                        src.Where(s => s.Rates.ContainsValue(src.SelectMany(m => m.Rates.Values).Max()))
                            .Select(d => d.Date).First()))
                .ForPath(dest => dest.AvgRate,
                    opt => opt.MapFrom(src => src.SelectMany(r => r.Rates.Values).Average()));
        }
    }
}
