using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Repositories
{
    public interface IOrderRepository
    {
        Task<Order?> GetById(int id);
        Task<Order?> Add(Order order);
    }
}
