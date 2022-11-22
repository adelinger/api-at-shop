using System;
namespace api_at_shop.Model.Products
{
    public class ProductVariant
    {
        public int ID { get; set; }
        public string? sku { get; set; }
        public int Price { get; set; }
        public int DiscountedPrice { get; set; }
        public string? Title { get; set; }
        public int Grams { get; set; }
        public bool Is_Enabled { get; set; }
        public bool Is_Default { get; set; }
        public bool Is_Available { get; set; }
        public List<int>? Options { get; set; }
        public int Quantity { get; set; }
    }
}

