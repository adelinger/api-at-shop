using System;
using api_at_shop.Repository.Entities;

namespace api_at_shop.Repository.Entites
{
	public class ProductOrderEntity
	{
        public int ProductOrderID { get; set; }
        public string PrintifyProductID { get; set; }
        public int CustomProductID { get; set; }
        public OrderEntity Order { get; set; }
        public int? VariantID { get; set; }
        public int Quantity { get; set; }

        public int? PrintProviderID { get; set; }
        public int? BluePrintID { get; set; }
        public string Sku { get; set; }
    }
}

