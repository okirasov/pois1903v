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
    public class ProductService : IProductService
    {
        private readonly APIDBContext _context;

        public ProductService(APIDBContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDTO>> Get()
        {
            var entities = await _context.Products.ToListAsync();
            return entities.Select(u => new ProductDTO(u)).ToList();
        }

        public async Task<ProductDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateOrUpdate(ProductDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Products.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public bool IsExist(int id)
        {
            return _context.Products.Any(e => e.ID == id);
        }
    }
}
