﻿using System;
using System.Net.Http.Headers;
using api_at_shop.Model;
using api_at_shop.Model.Products;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using api_at_shop.DTO.Printify.Data.Image;
using api_at_shop.DTO.Printify.Data.Variant;
using api_at_shop.DTO.Printify.Data;
using api_at_shop.DTO.Printify.Data.Option;

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

            Client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", TOKEN);

        }

        public Task<IProduct> DeleteProductAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IProduct> GetProductAsync(string id)
        {
            using HttpResponseMessage res = await Client.GetAsync(BASE_URL + "/products/"+id+".json");
            res.EnsureSuccessStatusCode();
            var product = await res.Content.ReadFromJsonAsync<PrintifyData>();
            var availableOptions = GetAvailableOptions(product);
            return new Product
            {
                Created_At = product.Created_At,
                Description = product.Description,
                ID = product.ID,
                Images = GetMappedImages(product),
                Visible = product.Visible,
                Variants = GetMappedVariants(product.Variants),
                Title = product.Title,
                Tags = product.Tags,
                Is_Locked = product.Is_Locked,
                Updated_At = product.Updated_At,
                Options = GetMappedOptions(product.Options),
                DefaultImages = GetDefaultImages(product),
                AvailableColors = availableOptions.Colors,
                AvailableSizes = availableOptions.Sizes,
            };
        }

        public async Task<List<IProduct>> GetProductsAsync()
        {
            try
            {
                using HttpResponseMessage res = await Client.GetAsync(BASE_URL + "/products.json");
                res.EnsureSuccessStatusCode();
                var product = await res.Content.ReadFromJsonAsync<PrintifyProductDTO>();

                var mapped = new List<IProduct>();

                foreach (var (item, possibleOptions) in from item in product?.Data
                                                        let possibleOptions = new List<List<int>>()
                                                        select (item, possibleOptions))
                {
                    possibleOptions.AddRange(from variant in item.Variants
                                             select variant.Options);
                    var availableOptions = GetAvailableOptions(item);
                    var availableColors = availableOptions.Colors;


                    var defaultImages = GetDefaultImages(item);

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
                        AvailableSizes = availableOptions.Sizes,
                        FeaturedImageSrc = item.Images?.FirstOrDefault(e => e.Is_Default == true)?.Src,
                        Images = GetMappedImages(item),
                        DefaultImages = defaultImages,
                        Variants = GetMappedVariants(item.Variants),
                        Options = GetMappedOptions(item.Options),

                    });
                }

                return mapped;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public Task<IProduct> UpdateProductAsync(IProduct product)
        {
            throw new NotImplementedException();
        }

        private List<ProductImage> GetDefaultImages(PrintifyData item)
        {
            var defaultImages = new List<ProductImage>();
            var defaultVariant = item.Variants.FirstOrDefault(e => e.Is_Default == true);
            foreach (var image in item.Images)
            {
                int index = image.Variant_Ids.FindIndex(item => item == defaultVariant?.ID);
                if (index >= 0)
                {
                    defaultImages.Add(new ProductImage
                    {
                        Src = image.Src,
                        Is_Default = image.Is_Default,
                        Is_Selected_For_Publishing = image.Is_Selected_For_Publishing,
                        Variant_Ids = image.Variant_Ids,
                        Position = image.Position,
                    });
                }
            }

            return defaultImages;
        }

        private List<List<int>> GetPossibleOptions(PrintifyData item)
        {
            var possibleOptions = new List<List<int>>();
            foreach (var variant in item.Variants)
            {
                if (variant.Is_Enabled)
                {
                    possibleOptions.Add(variant.Options);
                }
            }

            return possibleOptions;
        }     

        private ProductOptions GetAvailableOptions(PrintifyData item)
        {
            var options = new ProductOptions();
            var availableSizes = new List<ProductSize>();
            var availableColors = new List<ProductColor>();
            var possibleOptions = GetPossibleOptions(item);

                foreach (var option in item.Options)
                {
                        foreach (var value in option.Values)
                        {
                            foreach (var possibleOption in possibleOptions)
                            {
                                int index = possibleOption.FindIndex(item => item == value.ID);
                                if (index >= 0)
                                {
                            if (option.Name == "Colors")
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
                            else if (option.Name == "Sizes")
                            {
                                int hasIndex = availableSizes.FindIndex(item => item.ID == value.ID);
                                if (hasIndex < 0)
                                {
                                    availableSizes.Add(new ProductSize
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
            options.Sizes = availableSizes;
            options.Colors = availableColors;
            return options;
        }

        private List<ProductImage> GetMappedImages(PrintifyData data)
        {
            try
            {
                var mapped = new List<ProductImage>();


                foreach (var image in data.Images)
                {
                    var match = data.Variants?.FirstOrDefault(e => e.ID == image.Variant_Ids?.FirstOrDefault())?.Options;
                    var colors = data.Options?.Where(e => e.Name == "Colors").FirstOrDefault();
                    var printifyColor = new PrintifyValues();
                    foreach (var item in match)
                    {
                        var find = colors?.Values?.Where(e => e.ID == item);
                        if(find != null && find.Any())
                        {
                            printifyColor = find.FirstOrDefault();
                            break;
                        }
                    }

                    var colorMatch = new ProductColor
                    {
                        Colors = printifyColor?.Colors,
                        ID = printifyColor.ID,
                        Title = printifyColor?.Title,
                    };

                    mapped.Add(new ProductImage
                    {
                        Is_Default = image.Is_Default,
                        Is_Selected_For_Publishing = image.Is_Selected_For_Publishing,
                        Position = image.Position,
                        Src = image.Src,
                        Variant_Ids = image.Variant_Ids,
                        ColorID = colorMatch.ID
                    });
                }

                return mapped;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        private List<ProductOptions> GetMappedOptions(List<PrintifyOptions> printifyOptions)
        {
            var mapped = new List<ProductOptions>();

            foreach (var option in printifyOptions)
            {
                mapped.Add(new ProductOptions
                {
                    Name = option.Name,
                    Type = option.Type,
                    Values = option.Values
                });
            }

            return mapped;
        }

        private List<ProductVariant> GetMappedVariants(List<PrintifyVariants> printifyVariant)
        {
            var mapped = new List<ProductVariant>();

            foreach (var variant in printifyVariant)
            {
                if (variant.Is_Enabled)
                {
                    mapped.Add(new ProductVariant
                    {
                        Grams = variant.Grams,
                        ID = variant.ID,
                        Is_Available = variant.Is_Available,
                        Is_Default = variant.Is_Default,
                        Is_Enabled = variant.Is_Enabled,
                        sku = variant.sku,
                        Options = variant.Options,
                        Price = variant.Price,
                        Quantity = variant.Quantity,
                        Title = variant.Title
                    });
                }
               
            }

            return mapped;
        }
    }
}

