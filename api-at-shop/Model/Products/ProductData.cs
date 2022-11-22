using System;
namespace api_at_shop.Model.Products
{
	public class ProductData
	{
		public int Total { get; set; }
		public int rpp { get; set; }
        public List<IProduct> Product { get; set; }
	}
}

