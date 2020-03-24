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
            throw new NotImplementedException();
        }

        public async Task<ProductDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Create(ProductDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(int id, ProductDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
        
        public bool IsExist(int id)
        {
            return _context.Products.Any(e => e.ID == id);
        }
    }
}
