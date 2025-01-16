namespace EmployeeManagementSystem.DataAccess.Entities
{
    public class Employee : BaseEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public ICollection<EmployeeRoles>? EmployeeRoles { get; set; }
        public ICollection<Shift>? Shifts { get; set; }
    }
}
