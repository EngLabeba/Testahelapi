using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Common;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(OffersDbContext context) : base(context)
        {
        }

        public async Task<Employee?> GetByEmployeeIdAsync(string employeeId)
        {
            return await Context.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId && e.IsActive);
        }

        public async Task<IEnumerable<Employee>> GetActiveEmployeesAsync()
        {
            return await Context.Employees
                .Where(e => e.IsActive)
                .OrderBy(e => e.Name)
                .ToListAsync();
        }
    }
}
