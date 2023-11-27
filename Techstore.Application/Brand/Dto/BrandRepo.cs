using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techstore.Application.Interface;
using Techstore.Infrastructure;
using Techstore.Infrastructure.Data;

namespace Techstore.Application.Brand.Dto
{
    public class BrandRepo : IRepository<Domain.Entities.Brand>
    {
        private readonly TechStoreDbContext _techStoreDbContext;

        public BrandRepo(TechStoreDbContext techStoreDbContext)
        {
            _techStoreDbContext = techStoreDbContext;
        }

        public async Task<Domain.Entities.Brand> CreateAsync(Domain.Entities.Brand e)
        {
            await _techStoreDbContext.Brands.AddAsync(e);
            await _techStoreDbContext.SaveChangesAsync();
            return e;
        }

        public async Task<string> DeleteAsync(string id)
        {
            int result = await _techStoreDbContext.Brands
                .Where(e => e.brand_id.Equals(id))
                .ExecuteDeleteAsync();
            return result.ToString();
        }

        public async Task<List<Domain.Entities.Brand>> GetAllAsync()
        {
            return await _techStoreDbContext.Brands.ToListAsync();
        }

        public async Task<Domain.Entities.Brand> GetByIdAsync(string id)
        {
            return await _techStoreDbContext.Brands
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.brand_id.Equals(id));
        }

        public async Task<string> UpdateAsync(string id, Domain.Entities.Brand e)
        {
            int result = await _techStoreDbContext.Brands
                .Where(e => e.brand_id.Equals(id))
                .ExecuteUpdateAsync(setter => setter
                    .SetProperty(m => m.brand_id, e.brand_id)
                    .SetProperty(m => m.brand_name, e.brand_name)
                );

            return result.ToString();
        }
    }
}
