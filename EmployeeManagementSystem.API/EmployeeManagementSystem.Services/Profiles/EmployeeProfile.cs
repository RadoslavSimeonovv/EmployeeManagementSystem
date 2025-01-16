using AutoMapper;
using EmployeeManagementSystem.Services.Employee;
using CoreEmployee = EmployeeManagementSystem.DataAccess.Entities.Employee;

namespace EmployeeManagementSystem.Services.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<CoreEmployee, EmployeeItem>()
                .ForMember(x => x.Roles, src => src.MapFrom(src => src.EmployeeRoles));
        }
    }
}
