using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IProductService
    {
        Task<List<Product?>> Get();

    }
}
