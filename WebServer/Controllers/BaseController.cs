using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServer.Interfaces;
using WebServer.Logic;

namespace WebServer.Controllers
{
    [ApiController]
    public class BaseController<Entity> : ControllerBase
    {
        protected readonly IEntityService<Entity> _entityService;

        public BaseController(IEntityService<Entity> service)
        {
            _entityService = service;
        }

        [HttpGet]
        public virtual ActionResult<IEnumerable<Entity>> Get()
        {
            return _entityService.Get();
        }

        [HttpGet("{id}")]
        public virtual ActionResult<Entity> Get(int id)
        {
            return _entityService.Get(id);
        }

        [HttpPost]
        public virtual ActionResult Post([FromBody] Entity value)
        {
            bool result = _entityService.Create(value);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public virtual void Put(int id, [FromBody] Entity value)
        {
            bool result = _entityService.Update(id, value);
        }

        [HttpDelete("{id}")]
        public virtual ActionResult Delete(int id)
        {
            bool result = _entityService.Delete(id);
            if (!result)
                return NotFound();
            else
                return Ok();
        }
    }
}