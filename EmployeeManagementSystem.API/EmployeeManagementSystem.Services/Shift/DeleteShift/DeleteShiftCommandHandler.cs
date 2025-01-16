using AutoMapper;
using EmployeeManagementSystem.DataAccess.Repositories.Shift;
using MediatR;

namespace EmployeeManagementSystem.Services.Shift.DeleteShift
{
    public class DeleteShiftCommandHandler(IShiftRepository shiftRepository) : IRequestHandler<DeleteShiftCommand, bool>
    {
        private readonly IShiftRepository _shiftRepository = shiftRepository;

        public async Task<bool> Handle(DeleteShiftCommand request, CancellationToken cancellationToken)
            => await _shiftRepository.DeleteShift(request.ShiftId, cancellationToken).ConfigureAwait(false);
    }
}
