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
        public async Task<IEnumerable<IProduct>> Get()
        {
            //await RunAsync();

            var products = await ProductApiService.GetProductsAsync();
            return null;
        }

      
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IProduct> Get(int id)
        {
            var products = await ProductApiService.GetProductsAsync();
            return null;
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

