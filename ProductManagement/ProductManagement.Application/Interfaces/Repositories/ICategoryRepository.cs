﻿using ProductManagement.Domain.Entities.Catalog;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Application.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        IQueryable<Category> Categories { get; }

        Task<List<Category>> GetListAsync();

        Task<Category> GetByIdAsync(int CategoryId);

        Task<int> InsertAsync(Category Category);

        Task UpdateAsync(Category Category);

        Task DeleteAsync(Category Category);
    }
}