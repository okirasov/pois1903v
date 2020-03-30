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
            var entities = await _context.Orders.ToListAsync();
            return entities.Select(u => new OrderDTO(u)).ToList();
        }

        public async Task<OrderDTO> Get(int id)
        {
            var entity = await _context.Orders.FindAsync(id);
            if (entity != null)
                return new OrderDTO(entity);
            else
                return null;
        }

        public async Task<bool> CreateOrUpdate(OrderDTO dto)
        {
            if (dto.ID > 0 && !IsExist(dto.ID))
            {
                return false;
            }

            var order = new Order
            {
                OrderID = dto.OrderID,
                CreateDate = dto.CreateDate,
                ShipDate = dto.ShipDate,
                Price = dto.Price
            };

            if (dto.ProductID.HasValue)
            {
                var product = await _context.Products.FindAsync(dto.ProductID.Value);
                if (product != null)
                {
                    order.Product = product;
                }
            }

            if (dto.ID > 0)
            {
                _context.Entry(order).State = EntityState.Modified;
            }
            else
            {
                _context.Orders.Add(order);
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Orders.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            _context.Orders.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public bool IsExist(int id)
        {
            return _context.Orders.Any(e => e.ID == id);
        }
    }
}
