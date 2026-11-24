using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public interface IProductRepository
    {
        public Task <List<Product?>> Get();
    }
}
