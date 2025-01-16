namespace EmployeeManagementSystem.Services.Shift
{
    public class ShiftItem
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid RoleId { get; set; }
        public required string RoleName { get; set; }
    }
}
