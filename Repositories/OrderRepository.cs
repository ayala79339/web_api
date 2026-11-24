using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContext _context;
        public OrderRepository(DbContext context)
        {
            _context = context;
        }
        public async Task<Order?> GetById(int id)
        { 
            var order= await _context.FindAsync<Order>(id);
             
            return order;
        }
        public async Task<Order?> Add(Order order)
        {
            await _context.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
