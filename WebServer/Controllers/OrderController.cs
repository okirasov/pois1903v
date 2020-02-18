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
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            return new OrderService().Get();
        }

        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            return new OrderService().Get(id);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Order value)
        {
            var service = new OrderService();
            // validate Product
            var product = new ProductService().Get(value.ProductID);
            if (product == null)
            {
                return NotFound("Product not found");
            }

            bool result = service.Create(value);
            return Ok("Success");
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Order value)
        {
            var service = new OrderService();
            bool result = service.Update(id, value);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var service = new OrderService();
            bool result = service.Delete(id);
            if (!result)
                return NotFound();
            else
                return Ok();
        }
    }
}
