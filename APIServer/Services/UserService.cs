using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using APIServer.Model;
using APIServer.DTO;

namespace APIServer.Services
{
    public class UserService : IUserService
    {
        private readonly APIDBContext _context;

        public UserService(APIDBContext context)
        {
            _context = context;
        }

        public async Task<List<UserDTO>> Get()
        {
            return await _context.Users.Include(u => u.Company)
                .Select(u => new UserDTO(u)).ToListAsync();
        }

        public async Task<UserDTO> Get(int id)
        {
            var user = await _context.Users.Include(u => u.Company)
                .Where(u => u.ID == id).FirstOrDefaultAsync();

            if (user != null)
                return new UserDTO(user);
            else
                return null;
        }

        public async Task<bool> CreateOrUpdate(UserDTO dto)
        {
            // for Update request only!!!
            // check if User exists
            if (dto.ID > 0 && !IsExist(dto.ID))
            {
                return false;
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

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Users.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<bool> Login(string email, string password)
        {
            var user = await _context.Users
                .Where(u => u.Email == email && u.Password == password)
                .FirstOrDefaultAsync();

            return user != null;
        }

        public bool IsExist(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
    }
}
