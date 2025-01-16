using EmployeeManagementSystem.API.Models.Role;
using EmployeeManagementSystem.API.Models.Shift;

namespace EmployeeManagementSystem.API.Models.Employee
{
    public class EmployeeModelResponse
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public IEnumerable<ShiftModelResponse> Shifts { get; set; }
        public IEnumerable<RoleModelResponse> Roles { get; set; }
    }
}
