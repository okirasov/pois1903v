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
    public class CompanyService : ICompanyService
    {
        private readonly APIDBContext _context;

        public CompanyService(APIDBContext context)
        {
            _context = context;
        }

        public async Task<List<CompanyDTO>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<CompanyDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Create(CompanyDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(int id, CompanyDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
