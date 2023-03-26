using System.Collections.Generic;
using api_at_shop.Auth;
using api_at_shop.DTO.Printify.Shipping;
using api_at_shop.Model;
using api_at_shop.Model.Products;
using api_at_shop.Services;
using api_at_shop.Services.ProductServices.Common;
using api_at_shop.Utils.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;


namespace api_at_shop.Controllers
{
    [Route("api/[controller]/[action]")]
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    [Authorize]
    public class ProductsController : Controller
    {
        private IProductApiService ProductApiService;
        private ITranslationService TranslationService;

        public ProductsController(IProductApiService productApiService, ITranslationService translationService)
        {
            ProductApiService = productApiService;
            TranslationService = translationService;
        }

        // GET: api/values
        [EnableCors("AllowAll")]
        [HttpGet]
        public async Task<ActionResult<IProduct>> Get(string categoryFilter, string searchFilter, string sortOrder,
            string tagFilters, string type, string languageCulture = null, int? limit = null)
        {
            try
                {
                if(!string.IsNullOrEmpty(type) && type == "featured")
                {
                    var featuredProducts = await ProductApiService.GetFeaturedProducts(languageCulture);
                    return Ok(featuredProducts);
                }
                var products = await ProductApiService.GetProductsAsync(categoryFilter, searchFilter, limit ?? ProductConstants.DefaultRecordPerPage,
                    sortOrder, tagFilters, languageCulture);
                return Ok(products);

            }
            catch (Exception ex)
            {
                return BadRequest(new Response { Message = ex.Message, Success = false });
            }
        }

        [HttpGet]
        [Route("related-products")]
        public async Task<ActionResult<IProduct>> GetRelatedProducts(string productId, int limit, string languageCulture = null)
        {
            try
            {
                var relatedProducts = await ProductApiService.GetRelatedProducts(productId, limit, languageCulture);

                return Ok(relatedProducts);

            }
            catch (Exception ex)
            {
                return BadRequest(new Response { Message = ex.Message, Success = false });
            }
        }

        //GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IProduct>> GetProduct(string id, string languageCulture = null)
        {
            try
            {
                var product = await ProductApiService.GetProductAsync(id, languageCulture);

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { Message = ex.Message, Success = false });
            }

        }

        [HttpGet]
        [Route("featured-products")]
        public async Task<ActionResult<IProduct>> GetFeaturedProducts(string languageCulture = null)
        {
            try
            {
                var products = await ProductApiService.GetFeaturedProducts(languageCulture);
                return Ok(products);

            }
            catch (Exception ex)
            {
                return BadRequest(new Response { Message = ex.Message, Success = false });
            }
        }

        [HttpPost]
        [Route("calculate-shipping")]
        public async Task<ActionResult<IProduct>> CalculateShipping([FromBody] ShippingDTO AddressTo)
        {
            try
            {   
                var shippingPrice = await ProductApiService.GetShippingPrice(AddressTo);

                return Ok(shippingPrice);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { Message = ex.Message, Success = false });
            }

        }

        [HttpPost]
        [Route("new-order")]
        public async Task<ActionResult<IProduct>> NewOrder([FromBody] ShippingDTO AddressTo)
        {
            try
            {
                var result = await ProductApiService.MakeNewOrder(AddressTo);

                if (result.Success)
                {
                    var createInvoice = await ProductApiService.CreateInvoiceAsync(AddressTo);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { Message = ex.Message, Success = false });
            }

        }

        [HttpPost]
        [Route("validate-order")]
        public async Task<ActionResult<IProduct>> OrderValidation([FromBody] ShippingDTO AddressTo)
        {
            try
            {
                var result = await ProductApiService.IsOrderValid(AddressTo);

                return Ok(new Response { Success = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { Message = ex.Message, Success = false });
            }

        }

        [HttpPost]
        [Route("add-tag")]
        public async Task<ActionResult<IProduct>> AddTag(string id, string tag)
        {
            try
            {
                var task = await ProductApiService.AddTagAsync(id, tag);
                if (task.Success)
                    return Ok();
                else
                    return BadRequest(task);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { Message = ex.Message, Success = false });
            }

        }

        [HttpPost]
        [HttpPost("{id}/{tag}")]
        [Route("remove-tag")]
        public async Task<ActionResult<IProduct>> RemoveTag(string id, string tag)
        {
            try
            {
                var task = await ProductApiService.RemoveTagAsync(id, tag);
                if (task.Success)
                    return Ok();
                else
                    return BadRequest(task);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { Message = ex.Message, Success = false });
            }

        }

        // POST api/values
        [HttpPost]
        [Route("add-translation")]
        public async Task<IActionResult> AddProductTranslation([FromBody] ProductTranslation ProductTranslation)
        {
            try
            {
                var task = await TranslationService.AddProductTranslationAsycn(ProductTranslation);

                return Ok(task);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { Message = ex.Message, Success = false });
            }
        }
    }
}

