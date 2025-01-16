using AutoMapper;
using EmployeeManagementSystem.DataAccess.Repositories.Employee;
using EmployeeManagementSystem.DataAccess.Repositories.Shift;
using MediatR;

namespace EmployeeManagementSystem.Services.Shift.UpdateShift
{
    public class UpdateShiftCommandHandler(
        IShiftRepository shiftRepository, 
        IEmployeeRepository employeeRepository,
        IMapper mapper)
        : IRequestHandler<UpdateShiftCommand, UpdateShiftCommandResponse?>
    {
        private readonly IShiftRepository _shiftRepository = shiftRepository;
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<UpdateShiftCommandResponse?> Handle(UpdateShiftCommand command, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetEmployeeById(command.EmployeeId);

            if (employee == null)
            {
                return null;
            }

            if (!employee.EmployeeRoles!.Any(e => e.RoleId == command.RoleId))
            {
                return null;
            }

            var existingShift = await _shiftRepository.GetShiftById(command.Id, cancellationToken)
                .ConfigureAwait(false);

            if (existingShift == null)
            {
                return null;
            }
            
            existingShift.StartTime = command.StartTime;
            existingShift.EndTime = command.EndTime;
            existingShift.RoleId = command.RoleId;

            var updatedShift = await _shiftRepository.UpdateShift(existingShift, cancellationToken)
                .ConfigureAwait(false);

            return updatedShift is null ? null : _mapper.Map<UpdateShiftCommandResponse>(updatedShift);
        }
    }
}
