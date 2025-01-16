using CoreRole = EmployeeManagementSystem.DataAccess.Entities.Role;

namespace EmployeeManagementSystem.DataAccess.Repositories.Role
{
    public interface IRoleRepository
    {
        Task<IEnumerable<CoreRole>> GetRoles(CancellationToken cancellationToken);
    }
}
