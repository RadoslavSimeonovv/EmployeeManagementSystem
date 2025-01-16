using MediatR;

namespace EmployeeManagementSystem.Services.Shift.DeleteShift
{
    public class DeleteShiftCommand : IRequest<bool>
    {
        public Guid ShiftId { get; set; }
    }
}
