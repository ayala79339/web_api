using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Services
{
    public interface IOrderService
    {
        Task<Order> GetById(int id);
         
        Task<Order> Add(Order order);
    }
}
