using Microsoft.EntityFrameworkCore;
using CoreEmployee = EmployeeManagementSystem.DataAccess.Entities.Employee;

namespace EmployeeManagementSystem.DataAccess.Repositories.Employee
{
    public class EmployeeRepository(IEmployeeManagementDbContext dbContext) : IEmployeeRepository
    {
        private readonly IEmployeeManagementDbContext _dbContext = dbContext;

        public async Task<CoreEmployee?> GetEmployeeById(Guid id)
            => await _dbContext.Employees
                .Include(e => e.EmployeeRoles)
                .SingleOrDefaultAsync(e => e.Id == id);

        public async Task<IEnumerable<CoreEmployee>> GetEmployees()
        {
            var employees = await _dbContext.Employees
                .Include(e => e.EmployeeRoles)
                .Include(e => e.Shifts)!.ThenInclude(s => s.Role)
                .ToListAsync();

            return !employees.Any() ? Enumerable.Empty<CoreEmployee>() : employees;
        }
    }
}
