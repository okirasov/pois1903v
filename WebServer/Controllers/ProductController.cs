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
    [Route("api/products")]
    [ApiController]
    public class ProductController : BaseController<Product>
    {
        public ProductController(IProductService service) : base(service)
        {
        }

        public IProductService _service
        {
            get { return _entityService as IProductService; }
        }

        [HttpGet]
        public override ActionResult<IEnumerable<Product>> Get()
        {
            var products = _service.Get();
            foreach (var product in products)
            {
                product.Company = new CompanyService().Get(product.CompanyID);
            }

            return products;
        }

        [HttpGet("{id}")]
        public override ActionResult<Product> Get(int id)
        {
            var product = _service.Get(id);
            if (product != null && product.CompanyID > 0)
            {
                product.Company = new CompanyService().Get(product.CompanyID);
            }

            return product;
        }
    }
}
