using System;
using System.Collections.Generic;
using System.Text;
using Entities;


namespace Repositories
{
    public interface ICategoryRepository
    {
        public Task<List<Category?>> Get();
    }
}
