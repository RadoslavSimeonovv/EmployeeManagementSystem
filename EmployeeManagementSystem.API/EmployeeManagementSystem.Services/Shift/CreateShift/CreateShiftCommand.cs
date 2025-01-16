using MediatR;

namespace EmployeeManagementSystem.Services.Shift.CreateShift
{
    public class CreateShiftCommand : IRequest<CreateShiftCommandResponse?>
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid RoleId { get; set; }
    }
}
