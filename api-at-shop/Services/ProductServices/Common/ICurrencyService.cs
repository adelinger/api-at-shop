using System;
using api_at_shop.Model;

namespace api_at_shop.Services.ProductServices
{
	public interface ICurrencyService
	{
		public Task<int> ConvertUsdToEur(int usdValue, string usdRate, string eurRate);
		public Task<CurrencyDTO[]> GetCurrencies();
    }
}

