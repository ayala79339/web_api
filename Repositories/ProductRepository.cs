using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        readonly AppDbContext appContext;

        public  ProductRepository(AppDbContext appContext)
        {
            this.appContext = appContext;
        }
        public async Task<List<Product?>> Get()
        {
             return await appContext.Products.ToListAsync();
        }
    }
}
