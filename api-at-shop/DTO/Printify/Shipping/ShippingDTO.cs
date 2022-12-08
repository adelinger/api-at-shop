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
	}
}

