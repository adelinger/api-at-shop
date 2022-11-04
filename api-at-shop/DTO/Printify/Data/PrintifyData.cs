using System;
using api_at_shop.DTO.Printify.Data.Image;
using api_at_shop.DTO.Printify.Data.Variant;
using api_at_shop.DTO.Printify.Data.Option;

namespace api_at_shop.DTO.Printify.Data
{
    public class PrintifyData
    {
        public string? ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<string>? Tags { get; set; }
        public List<PrinfitfyOptions>? Options { get; set; }
        public List<PrintifyVariants>? Variants { get; set; }
        public List<PrintifyImages>? Images { get; set; }
        public string? Created_At { get; set; }
        public string? Updated_At { get; set; }
        public bool Visible { get; set; }
        public bool Is_Locked { get; set; }

    }
}

