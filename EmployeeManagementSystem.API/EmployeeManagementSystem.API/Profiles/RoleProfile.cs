using AutoMapper;
using EmployeeManagementSystem.API.Models.Role;
using EmployeeManagementSystem.Services.Role;
using EmployeeManagementSystem.Services.Role.GetRoles;

namespace EmployeeManagementSystem.API.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleItem, RoleModelResponse>();
            CreateMap<GetRolesQueryResponse, GetRolesResponse>();
        }
    }
}
