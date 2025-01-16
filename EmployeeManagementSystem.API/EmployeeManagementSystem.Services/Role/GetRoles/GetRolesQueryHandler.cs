using AutoMapper;
using EmployeeManagementSystem.DataAccess.Repositories.Role;
using MediatR;

namespace EmployeeManagementSystem.Services.Role.GetRoles
{
    public class GetRolesQueryHandler(IRoleRepository roleRepository, IMapper mapper) : IRequestHandler<GetRolesQuery, GetRolesQueryResponse?>
    {
        private readonly IRoleRepository _roleRepository = roleRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<GetRolesQueryResponse?> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            var result = new GetRolesQueryResponse();
            var roles = await _roleRepository.GetRoles(cancellationToken).ConfigureAwait(false);

            if (!roles.Any())
            {
                return null;
            }

            result.Items = _mapper.Map<IEnumerable<RoleItem>>(roles);

            return result;
        }
    }
}
