using AutoMapper;
using EmployeeManagementSystem.API.Models.Employee;
using EmployeeManagementSystem.Services.Employee.GetEmployees;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeManagementSystem.API.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController(IMediator mediator, IMapper mapper) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(OkResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NotFoundResult), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetEmployeesAsync()
        {
            var response = await _mediator.Send(new GetEmployeesQuery())
                .ConfigureAwait(false);

            return response == null ? NotFound() : Ok(_mapper.Map<GetEmployeesResponse>(response));
        }
    }
}
