using System;
using api_at_shop.Model;

namespace api_at_shop.Services
{
    public interface IProductApiService
    {
        public Task<List<IProduct>>GetProductsAsync();
        public Task<IProduct> GetProductAsync(string id);
        public Task<IProduct> UpdateProductAsync(IProduct product);
        public Task<IProduct> DeleteProductAsync(string id);

    }
}

