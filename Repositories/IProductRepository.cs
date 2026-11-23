using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public interface IProductReposetory
    {
        public Task <List<Product?>> Get();
    }
}
