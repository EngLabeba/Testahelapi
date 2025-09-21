using Application.Common.Repositories;
using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Common;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class DependentRepository : BaseRepository<Dependent>, IDependentRepository
    {
        public DependentRepository(OffersDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Dependent>> GetAllDependentsAsync()
        {
            return await Context.Dependents
                .Where(d => d.IsActive == true)
                .OrderBy(d => d.Relationship)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Dependent?> GetDependentByIdAsync(int id)
        {
            return await Context.Dependents
                .Where(d => d.Id == id && d.IsActive == true)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Dependent>> GetActiveDependentsAsync()
        {
            return await Context.Dependents
                .Where(d => d.IsActive == true)
                .OrderBy(d => d.Relationship)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
