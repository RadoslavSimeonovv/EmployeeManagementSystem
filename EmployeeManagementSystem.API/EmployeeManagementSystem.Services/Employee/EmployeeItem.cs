using EmployeeManagementSystem.Services.Role;
using EmployeeManagementSystem.Services.Shift;

namespace EmployeeManagementSystem.Services.Employee
{
    public class EmployeeItem
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public IEnumerable<ShiftItem>? Shifts { get; set; }
        public IEnumerable<RoleItem>? Roles { get; set; }
    }
}
