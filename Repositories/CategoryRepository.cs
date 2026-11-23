using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class CategoryReposetory : ICategoryReposetory
    {
        readonly AppDbContext appContext;

        public CategoryReposetory(AppDbContext appContext)
        {
            this.appContext = appContext;
        }
        public async Task<List<Category?>> Get()
        {
            return await appContext.Categories.ToListAsync();
        }
  
    }
}
