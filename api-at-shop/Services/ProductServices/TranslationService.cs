using System;
using api_at_shop.Model;
using api_at_shop.Model.Products;
using api_at_shop.Repository;
using api_at_shop.Repository.Entites;
using api_at_shop.Services.ProductServices.Common;
using Microsoft.EntityFrameworkCore;

namespace api_at_shop.Services.ProductServices
{
	public class TranslationService :ITranslationService
	{
        private readonly DataContext DataContext;

        public TranslationService(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public async Task<Response> AddProductTranslationAsycn(ProductTranslation ProductToTranslate)
        {
            try
            {
                var entity = new ProductTranslationEntity
                {
                    ProductID = ProductToTranslate.ProductID,
                    LanguageCulture = ProductToTranslate.LanguageCulture,
                    ProductTitle = ProductToTranslate.ProductTitle,
                    ProductDescription = ProductToTranslate.ProductDescription,
                };

                var alreadyExists = DataContext.ProductTranslations.Where(t => t.ProductID == entity.ProductID && t.LanguageCulture == entity.LanguageCulture).Any();

                if (!alreadyExists)
                {
                    await DataContext.ProductTranslations.AddAsync(entity);
                    await DataContext.SaveChangesAsync();

                    return new Response { Success = true };
                }

                return new Response { Success = false, Message = "Data already exists" };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Response> DeleteProductTranslationAsync(string productID, string languageCulture)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductTranslation> GetProductTranslationAsync(string productID, string languageCulture)
        {
            try
            {
                var entity = await DataContext.ProductTranslations.SingleAsync(p=>p.ProductID == productID && p.LanguageCulture == languageCulture);

                return new ProductTranslation
                {
                    ProductID = entity.ProductID,
                    ProductTranslationID = entity.ProductTranslationID,
                    LanguageCulture = entity.LanguageCulture,
                    ProductDescription = entity.ProductDescription,
                    ProductTitle = entity.ProductTitle
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<ProductTranslation> UpdateProductTranslationAsync(ProductTranslation ProductToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}

