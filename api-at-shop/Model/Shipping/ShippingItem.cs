﻿using System;
using System.Text.Json.Serialization;


namespace api_at_shop.Model.Shipping
{
    public class ShippingItem : IShippingItems
    {  
        public string Product_id { get; set; }
        public int? Variant_id { get; set; }
        public int Quantity { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }

        public int? Print_provider_id { get; set; }    
        public int? Blueprint_id { get; set; }
        public string Sku { get; set; }
    }
}

