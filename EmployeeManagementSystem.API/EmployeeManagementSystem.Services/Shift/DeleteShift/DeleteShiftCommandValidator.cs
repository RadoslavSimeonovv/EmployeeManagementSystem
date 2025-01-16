using FluentValidation;

namespace EmployeeManagementSystem.Services.Shift.DeleteShift
{
    public class DeleteShiftCommandValidator : AbstractValidator<DeleteShiftCommand>
    {
        public DeleteShiftCommandValidator()
        {
            RuleFor(x => x.ShiftId).NotNull().NotEmpty();
        }

    }
}
