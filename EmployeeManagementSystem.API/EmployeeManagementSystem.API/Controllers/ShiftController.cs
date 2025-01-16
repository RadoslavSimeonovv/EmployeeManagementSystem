using AutoMapper;
using EmployeeManagementSystem.API.Models.Shift;
using EmployeeManagementSystem.Services.Shift.CreateShift;
using EmployeeManagementSystem.Services.Shift.DeleteShift;
using EmployeeManagementSystem.Services.Shift.UpdateShift;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController(IMediator mediator, IMapper mapper) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(CreateShiftResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateShiftAsync(CreateShiftRequest request)
        {
            var response = await _mediator.Send(_mapper.Map<CreateShiftCommand>(request))
                .ConfigureAwait(false);

            return response == null ? BadRequest() : Ok(_mapper.Map<CreateShiftResponse>(response));
        }

        [HttpPut]
        [Route("update/{shiftId}")]
        [ProducesResponseType(typeof(UpdateShiftCommandResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateShiftAsync(Guid shiftId, UpdateShiftRequest request)
        {
            var updateRequest = _mapper.Map<UpdateShiftCommand>(request);
            updateRequest.Id = shiftId;

            var response = await _mediator.Send(updateRequest);
            return response == null ? BadRequest() : Ok(_mapper.Map<UpdateShiftCommandResponse>(response));
        }

        [HttpDelete]
        [Route("delete/{shiftId}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteShiftAsync(Guid shiftId)
        {
            var response = await _mediator.Send(new DeleteShiftCommand { ShiftId = shiftId })
                .ConfigureAwait(false);

            return Ok(response);
        }
    }
}
