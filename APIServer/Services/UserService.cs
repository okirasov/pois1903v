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

        public async Task<bool> Create(UserDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(int id, UserDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }


        public bool Login(string email, string password)
        {
            throw new NotImplementedException();
        }

    }
}
