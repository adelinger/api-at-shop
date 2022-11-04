using System;
using api_at_shop.DTO.Printify;
using api_at_shop.DTO.Printify.Data;
using api_at_shop.Model.Products;

namespace api_at_shop.Model
{
    public interface IProduct
    {
        public string? ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<string>? Tags { get; set; }
        public List<ProductColor>? AvailableColors { get; set; }
        public string? Created_At { get; set; }
        public string? Updated_At { get; set; }
        public bool Visible { get; set; }
        public bool Is_Locked { get; set; }
    }
}

