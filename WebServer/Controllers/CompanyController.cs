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
        public ActionResult<Company> Get(int id)
        {
            return new CompanyService().Get(id);
        }
    }
}
