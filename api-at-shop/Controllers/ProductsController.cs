using System.Collections.Generic;
using api_at_shop.Auth;
using api_at_shop.DTO.Printify.Shipping;
using api_at_shop.Model;
using api_at_shop.Services;
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

        public ProductsController(IProductApiService productApiService)
        {
            ProductApiService = productApiService;
        }

        // GET: api/values
        [EnableCors("AllowAll")]
        [HttpGet]
        public async Task<ActionResult<IProduct>> Get(string categoryFilter, string searchFilter, string sortOrder,
            string tagFilters, string type, int? limit = null)
        {
            try
                {
                if(!string.IsNullOrEmpty(type) && type == "featured")
                {
                    var featuredProducts = await ProductApiService.GetFeaturedProducts();
                    return Ok(featuredProducts);
                }
                var products = await ProductApiService.GetProductsAsync(categoryFilter, searchFilter, limit ?? ProductConstants.DefaultRecordPerPage,
                    sortOrder, tagFilters);
                return Ok(products);

            }
            catch (Exception ex)
            {
                return BadRequest(new Response { Message = ex.Message, Success = false });
            }
        }

        [HttpGet]
        [Route("related-products")]
        public async Task<ActionResult<IProduct>> GetRelatedProducts(string productId, int limit)
        {
            try
            {
                var relatedProducts = await ProductApiService.GetRelatedProducts(productId, limit);

                return Ok(relatedProducts);

            }
            catch (Exception ex)
            {
                return BadRequest(new Response { Message = ex.Message, Success = false });
            }
        }

        //GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IProduct>> GetProduct(string id)
        {
            try
            {
                var product = await ProductApiService.GetProductAsync(id);

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response { Message = ex.Message, Success = false });
            }

        }

        [HttpGet]
        [Route("featured-products")]
        public async Task<ActionResult<IProduct>> GetFeaturedProducts()
        {
            try
            {
                var products = await ProductApiService.GetFeaturedProducts();
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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

