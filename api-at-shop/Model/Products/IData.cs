using System;
using api_at_shop.DTO.Printify.Data.Image;
using api_at_shop.DTO.Printify.Data.Variant;

namespace api_at_shop.Model.Products
{
    public interface IData
    {
        public string? ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<object>? Tags { get; set; }
        public List<object>? Options { get; set; }
        public List<object>? Variants { get; set; }
        public List<object>? Images { get; set; }
        public string? Created_At { get; set; }
        public string? Updated_At { get; set; }
        public bool Visible { get; set; }
        public bool Is_Locked { get; set; }
    }
}

