using Domain.Entities;
using Domain.Common;
using Application.Common.Repositories;

namespace Application.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<Employee?> GetByEmployeeIdAsync(string employeeId);
        Task<IEnumerable<Employee>> GetActiveEmployeesAsync();
    }
}
