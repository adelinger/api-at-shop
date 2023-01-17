using System;
namespace api_at_shop.Repository.Entities
{
	public class OrderEntity
	{
        public int OrderID { get; set; }
        public DateTime TimeStamp { get; set; }
        public string PrintifyID { get; set; }
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
        public int ShippingMethod { get; set; }
        public bool SendShippingInformation { get; set; }
        public string ExternalID { get; set; }
        public string Label { get; set; }
    }
}

