using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIServer.DTO;
using APIServer.Interfaces;
using APIServer.Services;

namespace APIServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController<ProductDTO>
    {
        public ProductsController(IProductService service) : base(service)
        {
        }

        public IProductService _service
        {
            get { return _baseService as IProductService; }
        }
    }
}