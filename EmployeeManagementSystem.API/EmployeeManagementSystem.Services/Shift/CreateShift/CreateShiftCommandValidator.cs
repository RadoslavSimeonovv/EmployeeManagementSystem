using FluentValidation;

namespace EmployeeManagementSystem.Services.Shift.CreateShift
{
    public class CreateShiftCommandValidator : AbstractValidator<CreateShiftCommand>
    {
        public CreateShiftCommandValidator()
        {
            RuleFor(x => x.EmployeeId).NotNull().NotEmpty();
            RuleFor(x => x.RoleId).NotNull().NotEmpty();

            RuleFor(x => x.StartTime)
                .NotEmpty().WithMessage("Start time is required.");

            RuleFor(x => x.EndTime)
                .NotEmpty().WithMessage("End time is required.")
                .Must((command, endTime) => endTime > command.StartTime)
                .WithMessage("End time must be greater than start time.");
        }
    }
}
