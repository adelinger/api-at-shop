using System;
namespace api_at_shop.Model.Products
{
    public class ProductImage
    {
        public string? Src { get; set; }
        public List<int> Variant_Ids { get; set; }
        public string Position { get; set; }
        public bool Is_Default { get; set; }
        public bool Is_Selected_For_Publishing { get; set; }
        public int ColorID { get; set; }
    }
}

