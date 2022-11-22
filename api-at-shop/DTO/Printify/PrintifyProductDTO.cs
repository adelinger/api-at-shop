using System;
using api_at_shop.DTO.Printify;
using api_at_shop.DTO.Printify.Data;

namespace api_at_shop.Model
{
    public class PrintifyProductDTO
    {
        public int Current_Page { get; set; }
        public List<PrintifyData>? Data { get; set; }
        public string? First_Page_Url { get; set; }
        public int From { get; set; }
        public int Last_Page { get; set; }
        public string? Last_Page_Url { get; set; }
        public string? Next_Page_Url { get; set; }
        public string? Path { get; set; }
        public int Per_Page { get; set; }
        public string? Prev_Page_Url { get; set; }
        public int To { get; set; }
        public int Total { get; set; }
    }
}

