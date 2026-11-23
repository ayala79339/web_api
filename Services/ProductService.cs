using Entities; 
using Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo) => _repo = repo;
        public async Task<List<Product?>> Get()
        { 
            var list=await _repo.Get();
            return list;
        }
    }
}
