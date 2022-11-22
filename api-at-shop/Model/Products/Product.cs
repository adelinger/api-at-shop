using System;
using api_at_shop.Model.Products;

namespace api_at_shop.Model
{
    public class Product :IProduct
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
        public bool IsDiscounted { get; set; }
        public string? FeaturedImageSrc { get; set; }
        public int lowestPrice { get; set; }
        public string Currency { get; set; }
        public List<ProductImage> Images { get; set; }
        public List<ProductImage> DefaultImages { get; set; }
        public List<ProductVariant> Variants { get; set; }
        public List<ProductOptions> Options { get; set; }
        public List<ProductSize> AvailableSizes { get; set; }
    }
}

