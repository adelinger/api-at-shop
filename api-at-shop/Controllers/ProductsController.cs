using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_at_shop.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {

        static HttpClient client = new HttpClient();

            // GET: api/values
            [HttpGet]
        public async Task<string> Get()
        {
            //await RunAsync();
            var test = await GetProductAsync("");
            return test;
        }

        static async Task<string> GetProductAsync(string path)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiIzN2Q0YmQzMDM1ZmUxMWU5YTgwM2FiN2VlYjNjY2M5NyIsImp0aSI6IjM2MmJiY2M1ODQ5NWQ1ZjFjODZlNTJlMWEzNzU2YWIyYjE1OWU2NjQxMTU5ZTQ1MTFiMWU5ZGQ5ZjNiMDc4ZDc1ZWIyNGU5MmE3YjBkNmYzIiwiaWF0IjoxNjY1NzU0Nzc0LjIyNTMyOSwibmJmIjoxNjY1NzU0Nzc0LjIyNTMzMywiZXhwIjoxNjk3MjkwNzc0LjE3MjkyLCJzdWIiOiIxMDQwNDk4MSIsInNjb3BlcyI6WyJzaG9wcy5tYW5hZ2UiLCJzaG9wcy5yZWFkIiwiY2F0YWxvZy5yZWFkIiwib3JkZXJzLnJlYWQiLCJvcmRlcnMud3JpdGUiLCJwcm9kdWN0cy5yZWFkIiwicHJvZHVjdHMud3JpdGUiLCJ3ZWJob29rcy5yZWFkIiwid2ViaG9va3Mud3JpdGUiLCJ1cGxvYWRzLnJlYWQiLCJ1cGxvYWRzLndyaXRlIiwicHJpbnRfcHJvdmlkZXJzLnJlYWQiXX0.AmRSNVvODyIm5J4-YaddIGKNwR8ixW1o5dsYIQkn9VZfLy1PFFizIveipU50A6JyN06eVy5yCcfkDewLtL8");

            using HttpResponseMessage res = await client.GetAsync("https://api.printify.com/v1/shops/5374613/products.json");
            res.EnsureSuccessStatusCode();
            string responseBody = await res.Content.ReadAsStringAsync();
            return responseBody;

            //string product = "";
            //client.DefaultRequestHeaders.Authorization =
            //new AuthenticationHeaderValue("Bearer",
            //"eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiIzN2Q0YmQzMDM1ZmUxMWU5YTgwM2FiN2VlYjNjY2M5NyIsImp0aSI6IjM2MmJiY2M1ODQ5NWQ1ZjFjODZlNTJlMWEzNzU2YWIyYjE1OWU2NjQxMTU5ZTQ1MTFiMWU5ZGQ5ZjNiMDc4ZDc1ZWIyNGU5MmE3YjBkNmYzIiwiaWF0IjoxNjY1NzU0Nzc0LjIyNTMyOSwibmJmIjoxNjY1NzU0Nzc0LjIyNTMzMywiZXhwIjoxNjk3MjkwNzc0LjE3MjkyLCJzdWIiOiIxMDQwNDk4MSIsInNjb3BlcyI6WyJzaG9wcy5tYW5hZ2UiLCJzaG9wcy5yZWFkIiwiY2F0YWxvZy5yZWFkIiwib3JkZXJzLnJlYWQiLCJvcmRlcnMud3JpdGUiLCJwcm9kdWN0cy5yZWFkIiwicHJvZHVjdHMud3JpdGUiLCJ3ZWJob29rcy5yZWFkIiwid2ViaG9va3Mud3JpdGUiLCJ1cGxvYWRzLnJlYWQiLCJ1cGxvYWRzLndyaXRlIiwicHJpbnRfcHJvdmlkZXJzLnJlYWQiXX0.AmRSNVvODyIm5J4-YaddIGKNwR8ixW1o5dsYIQkn9VZfLy1PFFizIveipU50A6JyN06eVy5yCcfkDewLtL8");
            //HttpResponseMessage response = await client.GetAsync("https://api.printify.com/v1/shops/5374613/products/");
            //if (response.IsSuccessStatusCode)
            //{
            //    product = await response.Content.ReadAsAsync<string>();
            //}
            //return product;
        }   

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            var test = await GetProductAsync("");
            return test;
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

