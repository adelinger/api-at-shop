using System;
using System.Net.Http.Headers;
using api_at_shop.Model;

namespace api_at_shop.Services.printify
{
    public class PrintifyService :IProductApiService
    {
        private HttpClient Client;

        public PrintifyService()
        {
            Client = new HttpClient();
        }

        public Task<IProduct> DeleteProductAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IProduct> GetProductAsync(string id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiIzN2Q0YmQzMDM1ZmUxMWU5YTgwM2FiN2VlYjNjY2M5NyIsImp0aSI6IjM2MmJiY2M1ODQ5NWQ1ZjFjODZlNTJlMWEzNzU2YWIyYjE1OWU2NjQxMTU5ZTQ1MTFiMWU5ZGQ5ZjNiMDc4ZDc1ZWIyNGU5MmE3YjBkNmYzIiwiaWF0IjoxNjY1NzU0Nzc0LjIyNTMyOSwibmJmIjoxNjY1NzU0Nzc0LjIyNTMzMywiZXhwIjoxNjk3MjkwNzc0LjE3MjkyLCJzdWIiOiIxMDQwNDk4MSIsInNjb3BlcyI6WyJzaG9wcy5tYW5hZ2UiLCJzaG9wcy5yZWFkIiwiY2F0YWxvZy5yZWFkIiwib3JkZXJzLnJlYWQiLCJvcmRlcnMud3JpdGUiLCJwcm9kdWN0cy5yZWFkIiwicHJvZHVjdHMud3JpdGUiLCJ3ZWJob29rcy5yZWFkIiwid2ViaG9va3Mud3JpdGUiLCJ1cGxvYWRzLnJlYWQiLCJ1cGxvYWRzLndyaXRlIiwicHJpbnRfcHJvdmlkZXJzLnJlYWQiXX0.AmRSNVvODyIm5J4-YaddIGKNwR8ixW1o5dsYIQkn9VZfLy1PFFizIveipU50A6JyN06eVy5yCcfkDewLtL8");

            using HttpResponseMessage res = await client.GetAsync("https://api.printify.com/v1/shops/5374613/products.json");
            res.EnsureSuccessStatusCode();
            var product = await res.Content.ReadAsAsync<PrintifyProduct>();

            return product;
        }

        public Task<IProduct> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IProduct> UpdateProductAsync(IProduct product)
        {
            throw new NotImplementedException();
        }
    }
}

