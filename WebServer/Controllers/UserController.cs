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

        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <param name="item"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>            
        [HttpPost]
        public ActionResult Post([FromBody] User value)
        {
            var service = new UserService();
            bool result = service.Create(value);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {
            var service = new UserService();
            bool result = service.Update(id, value);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var service = new UserService();
            bool result = service.Delete(id);
            if (!result)
                return NotFound();
            else
                return Ok();
        }

        [HttpGet("login")]
        public ActionResult Login(string email, 
            string password)
        {
            var service = new UserService();
            bool result = service.Login(email, password);
            if (!result)
                return NotFound("Failed login");
            else
                return Ok("Success login");
        }
    }
}
