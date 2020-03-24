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
    public class OrderService : IOrderService
    {
        private readonly APIDBContext _context;

        public OrderService(APIDBContext context)
        {
            _context = context;
        }

        public async Task<List<OrderDTO>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<OrderDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Create(OrderDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(int id, OrderDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
        
        public bool IsExist(int id)
        {
            return _context.Orders.Any(e => e.ID == id);
        }
    }
}
