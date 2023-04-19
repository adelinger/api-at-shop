using System;
namespace api_at_shop.Model.Shipping
{
	public class Invoice
	{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceTimeStamp { get; set; }
        public List<InvoiceItem> ListOfItems { get; set;}
        public string OperatorName { get; set; }
        public decimal TotalPrice { get; set; }
        public string FilePath { get; set; }
        public string PaymentType { get; set; }
        public decimal ShippingPrice { get; set; }
    }
}

