using Microsoft.EntityFrameworkCore;
using CoreRole = EmployeeManagementSystem.DataAccess.Entities.Role;

namespace EmployeeManagementSystem.DataAccess.Repositories.Role
{
    public class RoleRepository(IEmployeeManagementDbContext dbContext) : IRoleRepository
    {
        private readonly IEmployeeManagementDbContext _dbContext = dbContext;
        public async Task<IEnumerable<CoreRole>> GetRoles(CancellationToken cancellationToken)
        {
            var roles = await _dbContext.Roles.ToListAsync();

            return roles.Any() ? roles : Enumerable.Empty<CoreRole>();
        }
    }
}
