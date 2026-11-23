using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        public CategoryService(ICategoryRepository repo) => _repo = repo;
        public async Task<List<Category?>> Get()
        {
            var list = await _repo.Get();
            return list;
        }
    }
}
