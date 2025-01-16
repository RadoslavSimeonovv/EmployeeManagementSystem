namespace EmployeeManagementSystem.Services.Shift.CreateShift
{
    public class CreateShiftCommandResponse
    {
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid RoleId { get; set; }
    }
}
