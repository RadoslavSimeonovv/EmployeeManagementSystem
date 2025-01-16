using AutoMapper;
using EmployeeManagementSystem.API.Controllers;
using FakeItEasy;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using EmployeeManagementSystem.API.Models.Employee;
using EmployeeManagementSystem.Services.Employee.GetEmployees;
using EmployeeManagementSystem.Services.Employee;
using FluentAssertions;

namespace EmployeeManagementSystem.Tests.EmployeeManagementSystem.Api.Tests.Controllers
{
    public class EmployeeControllerTests
    {
        private readonly EmployeeController _fakeEmployeeController;
        private readonly IMediator _fakeMediator;
        private readonly IMapper _fakeMapper;

        private readonly Guid EmployeeId = new Guid("388a37ae-4040-4961-a840-a728a2b95ac7");
        private const string EmployeeName = "David Peterson";

        public EmployeeControllerTests()
        {
            _fakeMediator = A.Fake<IMediator>();
            _fakeMapper = A.Fake<IMapper>();
            _fakeEmployeeController = new(_fakeMediator, _fakeMapper);
        }

        [Fact]
        public async Task GetEmployeesAsync_Should_Return_OK_With_Expected_Response()
        {
            //Arrange
            var expectedGetEmployeesResponse = new GetEmployeesResponse()
            {
                Items = new List<EmployeeModelResponse>()
                {
                    new EmployeeModelResponse()
                    {
                        Id = EmployeeId,
                        Name = EmployeeName
                    }
                }
            };

            var expectedGetEmployeesQueryResponse = new GetEmployeesQueryHandlerResponse()
            {
                Items = new List<EmployeeItem>()
                {
                    new EmployeeItem()
                    {
                        Id = EmployeeId,
                        Name = EmployeeName
                    }
                }
            };

            A.CallTo(() => _fakeMediator.Send(A<GetEmployeesQuery>.Ignored, default)).Returns(expectedGetEmployeesQueryResponse);


            A.CallTo(() => _fakeMapper.Map<GetEmployeesResponse>(A<GetEmployeesQueryHandlerResponse>
                                        .That
                                        .Matches(k => k.Items != null &&
                                            k.Items.Any(
                                                q => q.Id == EmployeeId &&
                                                q.Name == EmployeeName
                                                ))))
                .Returns(new GetEmployeesResponse()
                {
                    Items = new List<EmployeeModelResponse>()
                {
                    new EmployeeModelResponse()
                    {
                        Id = EmployeeId,
                        Name = EmployeeName
                    }}
                });

            //Act
            var result = await _fakeEmployeeController.GetEmployeesAsync();

            //Assert
            result
                .Should()
                .BeOfType<OkObjectResult>()
                .Which
                .Value
                .Should()
                .BeOfType<GetEmployeesResponse>()
                .Which
                .Should()
                .BeEquivalentTo(expectedGetEmployeesResponse);
        }

        [Fact]
        public async Task GetRolesAsync_Should_Return_Bad_Request()
        {
            //Arrange
            A.CallTo(() => _fakeMediator.Send(A<GetEmployeesQuery>.Ignored, default))
                .Returns<GetEmployeesQueryHandlerResponse?>(null);


            //Act
            var result = await _fakeEmployeeController.GetEmployeesAsync();

            //Assert
            result
                .Should()
                .BeOfType<NotFoundResult>();
        }
    }
}
