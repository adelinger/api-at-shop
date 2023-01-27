using System;
namespace api_at_shop.Model.Shipping
{
	public interface IShippingInformation
	{
        public List<ShippingItem> line_items { get; set; }
        public UserAddress address_to { get; set; }

        public int shipping_method { get; set; }
        public bool send_shipping_notification { get; set; }
        public string external_id { get; set; }
        public string label { get; set; }
        public string totalPrice { get; set; }
        public string shipping_price { get; set; }
    }
}

