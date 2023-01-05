using System;
using System.Dynamic;
using System.Reflection;
using api_at_shop.DTO.Printify.Data;
using api_at_shop.Model;
using api_at_shop.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace api_at_shop.Services.ProductServices
{
	public class HnbWebApiService :ICurrencyService
	{
        private const string API_URL = "https://api.hnb.hr/tecajn-eur/v3?valuta=EUR&valuta=USD";
        private HttpClient Client;
        private readonly IConfiguration Configuration;
        private readonly DataContext DataContext;

        public HnbWebApiService(IConfiguration configuration, DataContext dataContext)
        {
            Client = new HttpClient();
            Configuration = configuration;
            DataContext = dataContext;
        }

        public async Task<CurrencyDTO[]> GetCurrencies()
        {
            try
            {
                var offlineCurrencies = await GetOfflineCurrencyAsync();

                if (offlineCurrencies != null && offlineCurrencies.TimeStamp >= DateTime.Now.AddHours(-2))
                {
                    var eurCurrency = new CurrencyDTO
                    {
                        Currency = "EUR",
                        Date = offlineCurrencies.TimeStamp.ToString(),
                        MiddleEchangeRate = offlineCurrencies.EURValue.ToString()
                    };
                    var usdCurrency = new CurrencyDTO
                    {
                        Currency = "USD",
                        Date = offlineCurrencies.TimeStamp.ToString(),
                        MiddleEchangeRate = offlineCurrencies.USDValue.ToString()
                    };

                    return new CurrencyDTO[] { eurCurrency, usdCurrency };
                }
                else
                {
                    using HttpResponseMessage res = await Client.GetAsync(API_URL);
                    res.EnsureSuccessStatusCode();


                    var onlineCurrency = await res.Content.ReadFromJsonAsync<CurrencyDTO[]>();

                    await AddNewOfflineCurrencAsync(onlineCurrency);
                    return onlineCurrency;
                   
                }
            }
            catch (Exception ex)
            {
                return null;
            }
           
        }
       
        public async Task<int> ConvertUsdToEur(int usdValue, CurrencyDTO[] currencies)
        {

            try
            {
                decimal valueToConvert = usdValue;
                var calculated = Math.Round((Decimal.Parse(GetCurrencyRate("EUR", currencies)) /
                    Decimal.Parse(GetCurrencyRate("USD", currencies))) * valueToConvert, 2);
                int converted = (int)calculated;

                return converted;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
        private async Task<Currency> GetOfflineCurrencyAsync()
        {
            try
            {
                var currency = await DataContext.Currencies.OrderByDescending(t => t.TimeStamp).FirstOrDefaultAsync();

                return currency;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private async Task<Response> AddNewOfflineCurrencAsync(CurrencyDTO[] OnlineCurrency)
        {
            try
            {
                var eurValue = 1;
                var usdValue = Decimal.Parse(OnlineCurrency.Where(c => c.Currency == "USD").FirstOrDefault().MiddleEchangeRate);

                var toInsert = new Currency() { EURValue = eurValue, USDValue = usdValue, TimeStamp = DateTime.UtcNow.AddHours(1) };
                var insert = await DataContext.AddAsync(toInsert);
                await DataContext.SaveChangesAsync();
                return new Response { Success = true };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Message = ex.Message };
            }
        }

        private static string GetCurrencyRate(string currencyName, CurrencyDTO[] currencies)
        {
            return currencies?.Where(c => c.Currency == currencyName).FirstOrDefault().MiddleEchangeRate.Replace(",", string.Empty);
        }
    }
}

