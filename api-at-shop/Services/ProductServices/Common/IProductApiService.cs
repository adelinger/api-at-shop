using System;
using api_at_shop.DTO.Printify;
using api_at_shop.Model;
using api_at_shop.Model.Products;
using api_at_shop.Model.Shipping;

namespace api_at_shop.Services
{
    public interface IProductApiService
    {
        public Task<ProductData>GetProductsAsync(string categoryFilter="", string searchFilter="", int? limit = null, string sortOrder="",
            string tagFilters = "");
        public Task<IProduct> GetProductAsync(string id);
        public Task<IProduct> UpdateProductAsync(IProduct product);
        public Task<IProduct> DeleteProductAsync(string id);
        public Task<object> GetShippingPrice(IShippingInformation ShippingInformation);
        public Task<Response> AddTagAsync(string id, string tag);
        public Task<Response> RemoveTagAsync(string id, string tag);
        public Task<ProductData> GetFeaturedProducts();
        public Task<ProductData> GetRelatedProducts(string productId, int limit);
        public Task<Order> MakeNewOrder(IShippingInformation OrderDetails);
        public Task<bool> IsOrderValid(IShippingInformation OrderDetails);
    }
}

