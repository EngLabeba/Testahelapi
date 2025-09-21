using Application.Common.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IDependentRepository : IBaseRepository<Dependent>
    {
        Task<IEnumerable<Dependent>> GetAllDependentsAsync();
        Task<Dependent?> GetDependentByIdAsync(int id);
        Task<IEnumerable<Dependent>> GetActiveDependentsAsync();
    }
}
