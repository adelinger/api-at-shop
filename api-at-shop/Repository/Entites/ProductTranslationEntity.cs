using System;
using api_at_shop.Repository.Entities;

namespace api_at_shop.Repository.Entites
{
    public class ProductTranslationEntity
    {
        public int ProductTranslationID { get; set; }
        public string ProductID { get; set; }
        public string LanguageCulture { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
    }
}

