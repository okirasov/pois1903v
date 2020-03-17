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
    [Route("api/companies")]
    [ApiController]
    public class CompanyController : BaseController<Company>
    {
        public CompanyController(ICompanyService service) : base(service)
        {
        }

        public ICompanyService _service
        {
            get { return _entityService as ICompanyService; }
        }
    }
}
