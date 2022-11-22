using System;
using System.Dynamic;
using System.Reflection;
using api_at_shop.DTO.Printify.Data;
using api_at_shop.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace api_at_shop.Services.ProductServices
{
	public class HnbWebApiService :ICurrencyService
	{
        private const string API_URL = "https://api.hnb.hr/tecajn/v1?valuta=EUR&valuta=USD";
        private HttpClient Client;
        private readonly IConfiguration Configuration;

        public HnbWebApiService(IConfiguration configuration)
        {
            Client = new HttpClient();
            Configuration = configuration;
        }

        public async Task<CurrencyDTO[]> GetCurrencies()
        {
            using HttpResponseMessage res = await Client.GetAsync(API_URL);
            res.EnsureSuccessStatusCode();

            return await res.Content.ReadFromJsonAsync<CurrencyDTO[]>();
        }
       
        public async Task<int> ConvertUsdToEur(int usdValue, string usdRate, string eurRate)
        {

            try
            {
                decimal valueToConvert = usdValue;
                var calculated = Math.Round((Decimal.Parse(usdRate) / Decimal.Parse(eurRate)) * valueToConvert, 2);
                int converted = (int)calculated;

                return converted;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}

