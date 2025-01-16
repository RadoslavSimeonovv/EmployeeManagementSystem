using AutoMapper;
using EmployeeManagementSystem.Services.Shift;
using EmployeeManagementSystem.Services.Shift.CreateShift;
using EmployeeManagementSystem.Services.Shift.UpdateShift;
using CoreShift = EmployeeManagementSystem.DataAccess.Entities.Shift;

namespace EmployeeManagementSystem.Services.Profiles
{
    public class ShiftProfile : Profile
    {
        public ShiftProfile()
        {
            CreateMap<CreateShiftCommand, CoreShift>();
            CreateMap<CoreShift, CreateShiftCommandResponse>();

            CreateMap<CoreShift, UpdateShiftCommandResponse>();

            CreateMap<CoreShift, ShiftItem>()
                .ForMember(x => x.RoleName, src => src.MapFrom(src => src.Role!.Name));
        }
    }
}
