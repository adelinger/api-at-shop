using System;
namespace api_at_shop.Model.Products
{
	public class ProductTranslation
	{
        public int ProductTranslationID { get; set; }
        public string ProductID { get; set; }
        public string LanguageCulture { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
    }
}

