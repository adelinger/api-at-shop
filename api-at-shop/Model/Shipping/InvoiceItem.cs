using System;
namespace api_at_shop.Model.Shipping
{
	public class InvoiceItem
	{
        public string OnlineInvoiceItemID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}

