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
    [Route("api/companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Company>> Get()
        {
            return new CompanyService().Get();
        }

        [HttpGet("{id}")]
        public ActionResult<CompanyDTO> Get(int id)
        {
            var company = new CompanyService().Get(id);
            if (company == null)
                return NotFound();

            var products = new ProductService().Get()
                .Where(i => i.CompanyID == company.ID);

            var dto = new CompanyDTO
            {
                ID = company.ID,
                Name = company.Name,
                Address = company.Address,
                ProductList = string.Join(";", products.Select(i => i.Name)),
                ProductCount = products.Count()
            };

            return dto;

        }

        [HttpPost]
        public void Post([FromBody] Company value)
        {
            var service = new CompanyService();
            bool result = service.Create(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Company value)
        {
            var service = new CompanyService();
            bool result = service.Update(id, value);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var service = new CompanyService();
            bool result = service.Delete(id);
            if (!result)
                return NotFound();
            else
                return Ok();
        }
    }
}
