using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServer.Model;
using WebServer.Logic;
using WebServer.Interfaces;

namespace WebServer.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : BaseController<Order>
    {
        public OrderController(IOrderService service) : base(service)
        {
        }

        public IOrderService _service
        {
            get { return _entityService as IOrderService; }
        }


        [HttpPost]
        public override ActionResult Post([FromBody] Order value)
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
    }
}
