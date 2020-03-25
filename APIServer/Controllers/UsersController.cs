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
    public class UsersController : BaseController<UserDTO>
    {
        public UsersController(IUserService service) : base(service)
        {
        }

        public IUserService _service
        {
            get { return _baseService as IUserService; }
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var result = await _service.Login(email, password);

            if (result)
                return Ok("Success login");
            else
                return NotFound("Failed login");
        }
    }
}