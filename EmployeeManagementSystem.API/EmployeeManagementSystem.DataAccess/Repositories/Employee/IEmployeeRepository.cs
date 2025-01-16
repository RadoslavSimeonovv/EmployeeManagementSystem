using CoreEmployee = EmployeeManagementSystem.DataAccess.Entities.Employee;

namespace EmployeeManagementSystem.DataAccess.Repositories.Employee
{
    public interface IEmployeeRepository
    {
        Task<CoreEmployee?> GetEmployeeById(Guid id);
        Task<IEnumerable<CoreEmployee>> GetEmployees();
    }
}
