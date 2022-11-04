using System;
namespace api_at_shop.DTO.Printify.Data.Option
{
    public class PrintifyOptions
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public List<PrintifyValues>? Values { get; set; }
    }
}

