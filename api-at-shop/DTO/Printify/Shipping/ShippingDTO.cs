using System;
using System.Text.Json.Serialization;
using api_at_shop.Model;
using api_at_shop.Model.Shipping;

namespace api_at_shop.DTO.Printify.Shipping
{
	public class ShippingDTO :IShippingInformation
	{  
        [JsonPropertyName("line_items")]
        public List<ShippingItem> line_items { get; set; }
        [JsonPropertyName("address_to")]
        public UserAddress address_to { get; set; }

        [JsonPropertyName("shipping_method")]
        public int shipping_method { get; set; }
        [JsonPropertyName("send_shipping_notification")]
        public bool send_shipping_notification { get; set; }
        [JsonPropertyName("external_id")]
        public string external_id { get; set; }
        [JsonPropertyName("label")]
        public string label { get; set; }
    }
}

