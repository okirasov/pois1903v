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
            var companies = await _context.Companies.ToListAsync();
            return companies.Select(u => new CompanyDTO(u)).ToList();
        }

        public async Task<CompanyDTO> Get(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company != null)
                return new CompanyDTO(company);
            else
                return null;
        }

        public async Task<bool> Create(CompanyDTO dto)
        {
            if (dto == null)
                return false;

            var company = new Company
            {
                Name = dto.Name,
                Address = dto.Address
            };

            _context.Companies.Add(company);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> Update(int id, CompanyDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
        
        public bool IsExist(int id)
        {
            return _context.Companies.Any(e => e.ID == id);
        }
    }
}
