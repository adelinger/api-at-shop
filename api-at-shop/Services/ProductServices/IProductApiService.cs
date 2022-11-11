using System;
using api_at_shop.Model;

namespace api_at_shop.Services
{
    public interface IProductApiService
    {
        public Task<List<IProduct>>GetProductsAsync(string categoryFilter="", string searchFilter="", int? limit = null, string sortOrder="");
        public Task<IProduct> GetProductAsync(string id);
        public Task<IProduct> UpdateProductAsync(IProduct product);
        public Task<IProduct> DeleteProductAsync(string id);

    }
}

