using EmployeeManagementSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.DataAccess
{
    public interface IEmployeeManagementDbContext
    {
        DbSet<Employee> Employees { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Shift> Shifts { get; set; }
        DbSet<EmployeeRoles> EmployeeRoles { get; set; }
        Task<int> SaveAsync(CancellationToken cancellationToken);
    }
}
