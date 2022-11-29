using System;
using api_at_shop.Model;

namespace api_at_shop.Services.ProductServices
{
	public interface ICurrencyService
	{
		public Task<int> ConvertUsdToEur(int usdValue, CurrencyDTO[] currencies);

        public Task<CurrencyDTO[]> GetCurrencies();
    }
}

