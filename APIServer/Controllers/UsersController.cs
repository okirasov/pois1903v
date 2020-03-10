using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIServer;
using APIServer.Model;
using APIServer.DTO;

namespace APIServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly APIDBContext _context;

        public UsersController(APIDBContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<UserDTO> GetUsers()
        {
            return _context.Users.Include(u => u.Company)
                .Select(u => new UserDTO(u)).ToList();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.Include(u => u.Company)
                .Where(u => u.ID == id).FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            var dto = new UserDTO(user);

            return Ok(dto);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] UserDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // for Update request only!!!
            // check if User exists
            if (dto.ID > 0 && !UserExists(dto.ID))
            {
                return NotFound();
            }

            var user = new User
            {
                ID = dto.ID,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email
            };

            // Load Company
            if (dto.CompanyID.HasValue)
            {
                var company = await _context.Companies.FindAsync(dto.CompanyID.Value);
                if (company != null)
                {
                    user.Company = company;
                }
            }

            // Update Request
            if (dto.ID > 0)
            {
                _context.Entry(user).State = EntityState.Modified;
            }
            // Insert Request
            else
            {
                _context.Users.Add(user);
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.ID }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }


        [HttpGet("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _context.Users
                .Where(u => u.Email == email && u.Password == password)
                .FirstOrDefaultAsync();

            if (user == null)
                return NotFound("Failed login");
            else
                return Ok("Success login");
        }


        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
    }
}