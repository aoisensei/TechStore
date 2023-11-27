using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techstore.Application.Interface;
using Techstore.Infrastructure.Data;

namespace Techstore.Application.Category.Dto
{
    public class CategoryRepo : IRepository<Domain.Entities.Category>
    {
        private readonly TechStoreDbContext _techStoreDbContext;

        public CategoryRepo(TechStoreDbContext techStoreDbContext)
        {
            _techStoreDbContext = techStoreDbContext;
        }

        public async Task<Domain.Entities.Category> CreateAsync(Domain.Entities.Category e)
        {
            await _techStoreDbContext.Categories.AddAsync(e);
            await _techStoreDbContext.SaveChangesAsync();
            return e;
        }

        public async Task<string> DeleteAsync(string id)
        {
            int result = await _techStoreDbContext.Categories
                .Where(e => e.category_id.Equals(id))
                .ExecuteDeleteAsync();
            return result.ToString();
        }

        public async Task<List<Domain.Entities.Category>> GetAllAsync()
        {
            return await _techStoreDbContext.Categories.ToListAsync();
        }

        public async Task<Domain.Entities.Category> GetByIdAsync(string id)
        {
            return await _techStoreDbContext.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.category_id.Equals(id));
        }

        public async Task<string> UpdateAsync(string id, Domain.Entities.Category e)
        {
            int result = await _techStoreDbContext.Categories
                .Where(e => e.category_id.Equals(id))
                .ExecuteUpdateAsync(setter => setter
                    .SetProperty(m => m.category_id, e.category_id)
                    .SetProperty(m => m.category_name, e.category_name)
                );

            return result.ToString();
        }
    }
}
