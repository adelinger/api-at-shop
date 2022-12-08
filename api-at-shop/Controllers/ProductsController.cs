using api_at_shop.DTO.Printify.Shipping;
using api_at_shop.Model;
using api_at_shop.Services;
using api_at_shop.Utils.Constants;
using Microsoft.AspNetCore.Mvc;


namespace api_at_shop.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private IProductApiService ProductApiService;

        public ProductsController(IProductApiService productApiService)
        {
            ProductApiService = productApiService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IProduct>> Get(string categoryFilter, string searchFilter, string sortOrder,
            string tagFilters,int? limit = null)
        {
            try
                {
                var products = await ProductApiService.GetProductsAsync(categoryFilter, searchFilter, limit ?? ProductConstants.DefaultRecordPerPage,
                    sortOrder, tagFilters);
                return Ok(products);

            }
            catch (Exception ex)
            {
                return BadRequest(new Response { Message = ex.Message, Success = false });
            }
        }

      
        // GET api/values/5
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

        [HttpPost]
        [Route("CalculateShipping")]
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

