using System;
using api_at_shop.Model;
using api_at_shop.Model.Products;

namespace api_at_shop.Services.ProductServices.Common
{
	public interface ITranslationService
	{
		public Task<Response> AddProductTranslationAsycn(ProductTranslation ProductToTranslate);
		public Task<ProductTranslation> GetProductTranslationAsync(string productID, string languageCulture);
		public Task<ProductTranslation> UpdateProductTranslationAsync(ProductTranslation ProductToUpdate);
		public Task<Response> DeleteProductTranslationAsync(string productID, string languageCulture);
	}
}

