using AutoMapper;
using EmployeeManagementSystem.DataAccess.Repositories.Employee;
using EmployeeManagementSystem.DataAccess.Repositories.Shift;
using MediatR;
using CoreShift = EmployeeManagementSystem.DataAccess.Entities.Shift;

namespace EmployeeManagementSystem.Services.Shift.CreateShift
{
    public class CreateShiftCommandHandler(
        IShiftRepository shiftRepository,
        IEmployeeRepository employeeRepository,
        IMapper mapper)
        : IRequestHandler<CreateShiftCommand, CreateShiftCommandResponse?>
    {
        private readonly IShiftRepository _shiftRepository = shiftRepository;
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<CreateShiftCommandResponse?> Handle(CreateShiftCommand command, CancellationToken cancellationToken)
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

            var shift = _mapper.Map<CoreShift>(command);

            var response = await _shiftRepository.CreateShift(shift, cancellationToken)
                .ConfigureAwait(false);

            return response is null ? null!: _mapper.Map<CreateShiftCommandResponse>(response);
        }
    }
}
