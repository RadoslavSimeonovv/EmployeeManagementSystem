using AutoMapper;
using EmployeeManagementSystem.DataAccess.Repositories.Employee;
using MediatR;

namespace EmployeeManagementSystem.Services.Employee.GetEmployees
{
    public class GetEmployeesQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper) : IRequestHandler<GetEmployeesQuery, GetEmployeesQueryHandlerResponse?>
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<GetEmployeesQueryHandlerResponse?> Handle(GetEmployeesQuery query, CancellationToken cancellationToken)
        {
            var result = new GetEmployeesQueryHandlerResponse();

            var employees = await _employeeRepository.GetEmployees()
                .ConfigureAwait(false);

            if (!employees.Any())
            {
                return null!;
            }

            result.Items = _mapper.Map<IEnumerable<EmployeeItem>>(employees);

            return result;
        }
    }
}
