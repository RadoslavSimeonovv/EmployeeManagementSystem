using AutoMapper;
using EmployeeManagementSystem.DataAccess.Entities;
using EmployeeManagementSystem.DataAccess.Repositories.Role;
using EmployeeManagementSystem.Services.Role;
using EmployeeManagementSystem.Services.Role.GetRoles;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace EmployeeManagementSystem.Tests.EmployeeManagementSystem.Services.Tests.Services.Roles
{
    public class GetRolesQueryHandlerTests
    {
        private readonly GetRolesQueryHandler _fakeHandler;
        private readonly IMapper _fakeMapper;
        private readonly IRoleRepository _fakeRoleRepository;

        private readonly Guid RoleId = new Guid("388a37ae-4040-4961-a840-a728a2b95ac9");
        private const string RoleName = "Cleaner";

        public GetRolesQueryHandlerTests()
        {
            _fakeMapper = A.Fake<IMapper>();
            _fakeRoleRepository = A.Fake<IRoleRepository>();
            _fakeHandler = new GetRolesQueryHandler(_fakeRoleRepository, _fakeMapper);
        }

        [Fact]
        public async Task Handler_Should_Return_Expected_Object()
        {
            //Arrange
            var getQuery = new GetRolesQuery();

            var expectedGetQueryResponse = new GetRolesQueryResponse
            {
                Items = new List<RoleItem>()
                {
                    new RoleItem
                    {
                        Id = RoleId,
                        Name = RoleName
                    }
                }
            };

            A.CallTo(() => _fakeRoleRepository.GetRoles(default))
                    .Returns(new List<Role>()
                    {
                         new Role()
                         {
                            Id = RoleId,
                            Name = RoleName
                         }
                    });

            A.CallTo(() => _fakeMapper.Map<IEnumerable<RoleItem>>(A<IEnumerable<Role>>
                                       .That
                                       .Matches(x => x.Any(q =>
                                       q.Id == RoleId && q.Name == RoleName))))
               .Returns(new List<RoleItem>()
                {
                     new RoleItem
                    {
                         Id = RoleId,
                         Name = RoleName
                    }
                });

            //Act
            var result = await _fakeHandler.Handle(getQuery, default);

            //Assert
            A.CallTo(() => _fakeRoleRepository.GetRoles(default))
                .MustHaveHappenedOnceExactly();

            result
                .Should()
                .BeOfType<GetRolesQueryResponse>()
                .Which
                .Should()
                .BeEquivalentTo(expectedGetQueryResponse);
        }

        [Fact]
        public async Task Handler_Should_Return_Null_When_Roles_Response_From_Database_Is_Empty()
        {
            //Arrange
            var getQuery = new GetRolesQuery();


            A.CallTo(() => _fakeRoleRepository.GetRoles(default))
                    .Returns(new List<Role>()
                    { });

            //Act
            var result = await _fakeHandler.Handle(getQuery, default);

            //Assert
            A.CallTo(() => _fakeRoleRepository.GetRoles(default))
                .MustHaveHappened();

            result
                .Should()
                .BeNull();
        }
    }
}
