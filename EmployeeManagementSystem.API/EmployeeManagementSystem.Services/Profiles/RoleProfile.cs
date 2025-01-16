using AutoMapper;
using EmployeeManagementSystem.Services.Role;
using CoreRole = EmployeeManagementSystem.DataAccess.Entities.Role;
using CoreEmployeeRole = EmployeeManagementSystem.DataAccess.Entities.EmployeeRoles;

namespace EmployeeManagementSystem.Services.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<CoreRole, RoleItem>();

            CreateMap<CoreEmployeeRole, RoleItem>()
                .ForMember(x => x.Name, src => src.MapFrom(src => src.Role!.Name))
                .ForMember(x => x.Id, src => src.MapFrom(src => src.RoleId));
        }
    }
}
