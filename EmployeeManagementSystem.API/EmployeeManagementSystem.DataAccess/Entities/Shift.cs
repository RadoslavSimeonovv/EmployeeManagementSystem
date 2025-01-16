namespace EmployeeManagementSystem.DataAccess.Entities
{
    public class Shift : BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public Guid RoleId {  get; set; }
        public Role? Role { get; set; }
    }
}
