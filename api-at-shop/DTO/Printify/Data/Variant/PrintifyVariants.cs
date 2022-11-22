using System;
namespace api_at_shop.DTO.Printify.Data.Variant
{
    public class PrintifyVariants
    {
        public int ID { get; set; }
        public string? sku { get; set; }
        public int Price { get; set; }
        public string? Title { get; set; }
        public int Grams { get; set; }
        public bool Is_Enabled { get; set; }
        public bool Is_Default { get; set; }
        public bool Is_Available { get; set; }
        public List<int>? Options { get; set; }
        public int Quantity { get; set; }
    }
}

