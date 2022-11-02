using System;
using System.Net.Http.Headers;
using api_at_shop.Model;

namespace api_at_shop.Services.printify
{
    public class PrintifyService :IProductApiService
    {
        private HttpClient Client;
        private readonly IConfiguration Configuration;
        private readonly string BASE_URL;
        private readonly string TOKEN;

        public PrintifyService(IConfiguration configuration)
        {
            Client = new HttpClient();
            Configuration = configuration;
            BASE_URL = configuration.GetSection("AppSettings").GetSection("PrintifyApiUrl").Value;
            TOKEN = configuration.GetSection("AppSettings").GetSection("PrintifyToken").Value;
        }

        public Task<IProduct> DeleteProductAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IProduct> GetProductAsync(string id)
        {
            Client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", TOKEN);

            using HttpResponseMessage res = await Client.GetAsync(BASE_URL+"/products.json");
            res.EnsureSuccessStatusCode();
            var product = await res.Content.ReadAsAsync<PrintifyProduct>();

            return product;
        }

        public async Task<IEnumerable<IProduct>> GetProductsAsync()
        {
            Client.DefaultRequestHeaders.Authorization =
           new AuthenticationHeaderValue("Bearer", TOKEN);

            using HttpResponseMessage res = await Client.GetAsync(BASE_URL + "/products.json");
            res.EnsureSuccessStatusCode();
            var product = await res.Content.ReadAsAsync<IEnumerable<PrintifyProduct>>();

            return product;
        }

        public Task<IProduct> UpdateProductAsync(IProduct product)
        {
            throw new NotImplementedException();
        }
    }
}

