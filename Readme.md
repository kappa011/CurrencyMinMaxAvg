# Currency Exchange Rates API - Min, Max, Average

This .NET Core 2.2 Web API returns historical exchange rate information.

It connects to and uses another API provided by the ECB as its data source.
That API is documented at [https://exchangeratesapi.io/](https://exchangeratesapi.io/).

## Installation

The repo contains entire Visual Studio project. The Web API can be:

- Hosted and run locally, from Visual Studio on IIS Express
- Hosted on Windows with IIS ([description](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/iis/?view=aspnetcore-2.2))
- Hosted in a Windows Service ([description](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/windows-service?view=aspnetcore-2.2&tabs=visual-studio))
- Published to Azure with Visual Studio ([description](https://docs.microsoft.com/en-us/aspnet/core/tutorials/publish-to-azure-webapp-using-vs?view=aspnetcore-2.2))

## Description

> Swagger UI page with details available at root URL (eg. https://localhost:44370)

The service exposes an endpoint that accepts this input:

- base currency\*
- target currency\*
- comma delimited set of dates

> \*_Available currency values:_ AUD, BGN, BRL, CAD, CHF, CNY, CZK, DKK, EUR, GBP, HKD, HRK, HUF, IDR, ILS, INR, ISK, JPY, KRW, MXN, MYR, NOK, NZD, PHP, PLN, RON, RUB, SEK, SGD, THB, TRY, USD, ZAR

The service returns the following information, aggregated from values provided for each individual date:

- minimum exchange rate during the period
- maximum exchange rate during the period
- average exchange rate during the period

## Example usage and return values

Given this input

- baseCurrency: SEK
- targetCurrency: NOK
- dates: 2018-02-01,2018-02-15,2018-03-01

The service returns this information:

- A min rate of 0.9546869595 on 2018-03-01
- A max rate of 0.9815486993 on 2018-02-15
- An average rate of 0.970839476467

REQUEST:

> ht<span>tps://</span>localhost:44370/api/getrates/SEK/NOK?dates=2018-02-01,2018-02-15,2018-03-01

RESPONSE: (_Web Surge_ average response time ~ 15ms)

```json
{
  "baseCurrency": "SEK",
  "targetCurrency": "NOK",
  "minRate": {
    "value": 0.9546869595,
    "date": "2018-03-01"
  },
  "maxRate": {
    "value": 0.9815486993,
    "date": "2018-02-15"
  },
  "avgRate": 0.9708394764666667
}
```

REQUEST:

> ht<span>tps://</span>localhost:44370/api/getrates/EUR/USD?dates=2018-01-02,2018-01-03,2018-01-04,2018-01-05,2018-01-08,2018-01-09,2018-01-10,2018-01-11,2018-01-12,2018-01-15,2018-01-16,2018-01-17,2018-01-18,2018-01-19,2018-01-22,2018-01-23,2018-01-24,2018-01-25,2018-01-26,2018-01-29,2018-01-30,2018-01-31,2018-02-01,2018-02-02,2018-02-05,2018-02-06,2018-02-07,2018-02-08,2018-02-09,2018-02-12,2018-02-13,2018-02-14,2018-02-15,2018-02-16,2018-02-19,2018-02-20,2018-02-21,2018-02-22,2018-02-23,2018-02-26,2018-02-27,2018-02-28,2018-03-01,2018-03-02,2018-03-05,2018-03-06,2018-03-07,2018-03-08,2018-03-09,2018-03-12,2018-03-13,2018-03-14,2018-03-15,2018-03-16,2018-03-19,2018-03-20,2018-03-21,2018-03-22,2018-03-23,2018-03-26,2018-03-27,2018-03-28,2018-03-29,2018-04-03,2018-04-04,2018-04-05,2018-04-06,2018-04-09,2018-04-10,2018-04-11,2018-04-12,2018-04-13,2018-04-16,2018-04-17,2018-04-18,2018-04-19,2018-04-20,2018-04-23,2018-04-24,2018-04-25,2018-04-26,2018-04-27,2018-04-30,2018-05-02,2018-05-03,2018-05-04,2018-05-07,2018-05-08,2018-05-09,2018-05-10,2018-05-11,2018-05-14,2018-05-15,2018-05-16,2018-05-17,2018-05-18,2018-05-21,2018-05-22,2018-05-23,2018-05-24,2018-05-25,2018-05-28,2018-05-29,2018-05-30,2018-05-31,2018-06-01,2018-06-04,2018-06-05,2018-06-06,2018-06-07,2018-06-08,2018-06-11,2018-06-12,2018-06-13,2018-06-14,2018-06-15,2018-06-18,2018-06-19,2018-06-20,2018-06-21,2018-06-22,2018-06-25,2018-06-26,2018-06-27,2018-06-28,2018-06-29,2018-07-02,2018-07-03,2018-07-04,2018-07-05,2018-07-06,2018-07-09,2018-07-10,2018-07-11,2018-07-12,2018-07-13,2018-07-16,2018-07-17,2018-07-18,2018-07-19,2018-07-20,2018-07-23,2018-07-24,2018-07-25,2018-07-26,2018-07-27,2018-07-30,2018-07-31,2018-08-01,2018-08-02,2018-08-03,2018-08-06,2018-08-07,2018-08-08,2018-08-09,2018-08-10,2018-08-13,2018-08-14,2018-08-15,2018-08-16,2018-08-17,2018-08-20,2018-08-21,2018-08-22,2018-08-23,2018-08-24,2018-08-27,2018-08-28,2018-08-29,2018-08-30,2018-08-31

RESPONSE: (_Web Surge_ average response time ~ 32ms)

```json
{
  "baseCurrency": "EUR",
  "targetCurrency": "USD",
  "minRate": {
    "value": 1.1321,
    "date": "2018-08-15"
  },
  "maxRate": {
    "value": 1.2493,
    "date": "2018-02-15"
  },
  "avgRate": 1.1975181286549708
}
```

## TO-DO

Unit tests and additional validation (potentially with ActionFilters or RouteConstraints)
