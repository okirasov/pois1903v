using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebServer.Model;
using WebServer.Logic;

namespace WebServer.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return new UserService().Get();
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return new UserService().Get(id);
        }

        [HttpPost]
        public void Post([FromBody] User value)
        {
            var service = new UserService();
            bool result = service.Create(value);

        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
