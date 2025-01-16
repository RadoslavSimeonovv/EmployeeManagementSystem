using AutoMapper;
using EmployeeManagementSystem.API.Models.Employee;
using EmployeeManagementSystem.Services.Employee;
using EmployeeManagementSystem.Services.Employee.GetEmployees;

namespace EmployeeManagementSystem.API.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeItem, EmployeeModelResponse>();
            CreateMap<GetEmployeesQueryHandlerResponse, GetEmployeesResponse>();
        }
    }
}
