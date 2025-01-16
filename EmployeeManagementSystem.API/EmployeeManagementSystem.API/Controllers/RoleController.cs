using AutoMapper;
using EmployeeManagementSystem.API.Models.Role;
using EmployeeManagementSystem.Services.Role.GetRoles;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeManagementSystem.API.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController(IMediator mediator, IMapper mapper) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(GetRolesResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NotFoundResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRolesAsync()
        {
            var response = await _mediator.Send(new GetRolesQuery())
                .ConfigureAwait(false);

            return response == null ? NotFound() : Ok(_mapper.Map<GetRolesResponse>(response));
        }
    }
}
