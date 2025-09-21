using Application.Common.Repositories;
using Application.Repositories;
using Domain.Entities;
using Persistence.Common;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<OfferCategory>, ICategoryRepository
    {
        public CategoryRepository(OffersDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<OfferCategory>> GetAllCategoriesAsync()
        {
            return await GetAllAsync();
        }

        public async Task<OfferCategory?> GetCategoryByIdAsync(int id)
        {
            return await GetByIdAsync(id);
        }
    }
}
