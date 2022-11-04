using System;
namespace api_at_shop.DTO.Printify.Data.Image
{
    public class PrintifyImages
    {
        public string? Src { get; set; }
        public List<int>? Variant_Ids { get; set; }
        public string? Position { get; set; }
        public bool Is_Default { get; set; }
        public bool Is_Selected_For_Publishing { get; set; }
    }
}

