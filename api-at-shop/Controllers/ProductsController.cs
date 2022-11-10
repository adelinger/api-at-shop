using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime;
using System.Threading.Tasks;
using api_at_shop.Model;
using api_at_shop.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public async Task<ActionResult<IProduct>> Get(string categoryFilter, string searchFilter)
        {
            try
            {
                var products = await ProductApiService.GetProductsAsync(categoryFilter, searchFilter);
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

