using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Order> Add(Order order)
        {
            return await _orderRepository.Add(order);
        }

        public async Task<Order> GetById(int id)
        {
            return await _orderRepository.GetById(id);
        }
    }
}   
 
