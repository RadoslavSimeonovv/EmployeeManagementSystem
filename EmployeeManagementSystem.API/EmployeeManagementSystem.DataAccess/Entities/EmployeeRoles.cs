namespace EmployeeManagementSystem.DataAccess.Entities
{
    public class EmployeeRoles : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public Guid RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
