using AutoMapper;
using EmployeeManagementSystem.API.Controllers;
using EmployeeManagementSystem.API.Models.Role;
using EmployeeManagementSystem.Services.Role;
using EmployeeManagementSystem.Services.Role.GetRoles;
using FakeItEasy;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace EmployeeManagementSystem.Tests.EmployeeManagementSystem.Api.Tests.Controllers
{
    public class RoleControllerTests
    {
        private readonly RoleController _fakeRoleController;
        private readonly IMediator _fakeMediator;
        private readonly IMapper _fakeMapper;

        private readonly Guid RoleId = new Guid("388a37ae-4040-4961-a840-a728a2b95ac9");
        private const string RoleName = "Cleaner";

        public RoleControllerTests()
        {
            _fakeMediator = A.Fake<IMediator>();
            _fakeMapper = A.Fake<IMapper>();
            _fakeRoleController = new(_fakeMediator, _fakeMapper);
        }

        [Fact]
        public async Task GetRolesAsync_Should_Return_OK_With_Expected_Response()
        {
            //Arrange
            var expectedGetRolesResponse = new GetRolesResponse()
            {
                Items = new List<RoleModelResponse>()
                {
                    new RoleModelResponse()
                    {
                        Id = RoleId,
                        Name = RoleName
                    }
                }
            };

            var expectedGetRolesQueryResponse = new GetRolesQueryResponse()
            {
                Items = new List<RoleItem>()
                {
                    new RoleItem()
                    {
                        Id = RoleId,
                        Name = RoleName
                    }
                }
            };

            A.CallTo(() => _fakeMediator.Send(A<GetRolesQuery>.Ignored, default)).Returns(expectedGetRolesQueryResponse);


            A.CallTo(() => _fakeMapper.Map<GetRolesResponse>(A<GetRolesQueryResponse>
                                        .That
                                        .Matches(k => k.Items != null &&
                                            k.Items.Any(
                                                q => q.Id == RoleId &&
                                                q.Name == RoleName
                                                ))))
                .Returns(new GetRolesResponse()
                {
                    Items = new List<RoleModelResponse>()
                {
                    new RoleModelResponse()
                    {
                        Id = RoleId,
                        Name = RoleName
                    }}
                });

            //Act
            var result = await _fakeRoleController.GetRolesAsync();

            //Assert
            result
                .Should()
                .BeOfType<OkObjectResult>()
                .Which
                .Value
                .Should()
                .BeOfType<GetRolesResponse>()
                .Which
                .Should()
                .BeEquivalentTo(expectedGetRolesResponse);
        }

        [Fact]
        public async Task GetRolesAsync_Should_Return_Bad_Request()
        {
            //Arrange
            A.CallTo(() => _fakeMediator.Send(A<GetRolesQuery>.Ignored, default))
                .Returns<GetRolesQueryResponse?>(null);


            //Act
            var result = await _fakeRoleController.GetRolesAsync();

            //Assert
            result
                .Should()
                .BeOfType<NotFoundResult>();
        }
    }
}
