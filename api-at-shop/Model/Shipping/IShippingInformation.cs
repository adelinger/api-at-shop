using System;
namespace api_at_shop.Model.Shipping
{
	public interface IShippingInformation
	{
        public List<ShippingItem> line_items { get; set; }
        public UserAddress address_to { get; set; }
    }
}

