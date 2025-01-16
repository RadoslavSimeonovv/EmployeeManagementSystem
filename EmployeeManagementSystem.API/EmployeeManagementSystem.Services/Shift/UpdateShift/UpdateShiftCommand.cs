﻿using MediatR;

namespace EmployeeManagementSystem.Services.Shift.UpdateShift
{
    public class UpdateShiftCommand : IRequest<UpdateShiftCommandResponse?>
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid RoleId { get; set; }
    }
}
