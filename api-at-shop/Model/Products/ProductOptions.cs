using System;
using api_at_shop.DTO.Printify.Data.Option;

namespace api_at_shop.Model.Products
{
    public class ProductOptions
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public List<PrintifyValues>? Values { get; set; }

        public List<ProductColor> Colors { get; set; }
        public List<ProductSize> Sizes { get; set; }
    }
}

