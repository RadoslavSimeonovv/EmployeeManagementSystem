using AutoMapper;
using EmployeeManagementSystem.API.Models.Shift;
using EmployeeManagementSystem.Services.Shift;
using EmployeeManagementSystem.Services.Shift.CreateShift;
using EmployeeManagementSystem.Services.Shift.UpdateShift;

namespace EmployeeManagementSystem.API.Profiles
{
    public class ShiftProfile : Profile
    {
        public ShiftProfile()
        {
            CreateMap<CreateShiftRequest, CreateShiftCommand>();
            CreateMap<CreateShiftCommandResponse, CreateShiftResponse>();

            CreateMap<UpdateShiftRequest, UpdateShiftCommand>();
            CreateMap<UpdateShiftResponse, UpdateShiftCommandResponse>();

            CreateMap<ShiftItem, ShiftModelResponse>();
        }
    }
}
