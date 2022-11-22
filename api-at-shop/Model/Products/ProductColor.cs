using System;
namespace api_at_shop.Model.Products
{
    public class ProductColor
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public List<string>? Colors { get; set; }
    }
}

