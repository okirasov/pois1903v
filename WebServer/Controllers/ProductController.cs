using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServer.Model;
using WebServer.Logic;

namespace WebServer.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = new ProductService().Get();
            foreach (var product in products)
            {
                product.Company = new CompanyService().Get(product.CompanyID);
            }

            return products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = new ProductService().Get(id);
            if (product != null && product.CompanyID > 0)
            {
                product.Company = new CompanyService().Get(product.CompanyID);
            }

            return product;
        }

        [HttpPost]
        public void Post([FromBody] Product value)
        {
            var service = new ProductService();
            bool result = service.Create(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product value)
        {
            var service = new ProductService();
            bool result = service.Update(id, value);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var service = new ProductService();
            bool result = service.Delete(id);
            if (!result)
                return NotFound();
            else
                return Ok();
        }
    }
}
