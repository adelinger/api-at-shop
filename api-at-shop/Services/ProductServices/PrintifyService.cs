using System;
using System.Net.Http.Headers;
using api_at_shop.Model;
using api_at_shop.Model.Products;
using Microsoft.AspNetCore.Mvc;

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
            return null;
        }

        public async Task<List<IProduct>> GetProductsAsync()
        {
            Client.DefaultRequestHeaders.Authorization =
           new AuthenticationHeaderValue("Bearer", TOKEN);

            using HttpResponseMessage res = await Client.GetAsync(BASE_URL + "/products.json");
            res.EnsureSuccessStatusCode();
            var product = await res.Content.ReadFromJsonAsync<PrintifyProductDTO>();

            var mapped = new List<IProduct>();
            foreach (var item in product.Data)
            {
                var possibleOptions = new List<List<int>>();
                foreach (var variant in item.Variants)
                {
                    possibleOptions.Add(variant.Options);
                }

                var availableColors = new List<ProductColor>();
                foreach (var option in item.Options)
                {
                    if(option.Name == "Colors")
                    {

                        foreach (var value in option.Values)
                        {
                            foreach (var possibleOption in possibleOptions.Distinct())
                            { 
                                int index = possibleOption.FindIndex(item => item == value.ID);
                                if (index >= 0)
                                {
                                    int hasIndex = availableColors.FindIndex(item => item.ID == value.ID);
                                    if (hasIndex < 0)
                                    {
                                        availableColors.Add(new ProductColor
                                        {
                                            ID = value.ID,
                                            Colors = value.Colors,
                                            Title = value.Title
                                        });
                                    }
                                   
                                }
                                
                            }
                        }
                    }
                }

                mapped.Add(new Product
                {
                    ID = item.ID,
                    Created_At = item.Created_At,
                    Description = item.Description,
                    Is_Locked = item.Is_Locked,
                    Tags = item.Tags,
                    Title = item.Title,
                    Updated_At = item.Updated_At,
                    Visible = item.Visible,
                    AvailableColors = availableColors,
                });
            }

            

            return mapped;
        }

        public Task<IProduct> UpdateProductAsync(IProduct product)
        {
            throw new NotImplementedException();
        }
    }
}

