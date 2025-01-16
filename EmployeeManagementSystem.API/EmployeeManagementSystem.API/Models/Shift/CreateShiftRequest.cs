namespace EmployeeManagementSystem.API.Models.Shift
{
    public class CreateShiftRequest
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid RoleId { get; set; }
    }
}
