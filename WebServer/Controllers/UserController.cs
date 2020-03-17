using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebServer.Model;
using WebServer.Logic;
using WebServer.Interfaces;

namespace WebServer.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : BaseController<User>
    {
        public UserController(IUserService service) : base(service)
        {
        }

        public IUserService _service
        {
            get { return _entityService as IUserService; }
        }

        [HttpGet("login")]
        public ActionResult Login(string email, string password)
        {
            bool result = _service.Login(email, password);
            if (!result)
                return NotFound("Failed login");
            else
                return Ok("Success login");
        }
    }
}
