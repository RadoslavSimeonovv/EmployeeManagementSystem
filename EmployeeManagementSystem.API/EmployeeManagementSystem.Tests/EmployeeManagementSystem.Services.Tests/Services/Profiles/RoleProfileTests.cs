using AutoMapper;
using EmployeeManagementSystem.DataAccess.Entities;
using EmployeeManagementSystem.Services.Profiles;
using EmployeeManagementSystem.Services.Role;
using FluentAssertions;
using Xunit;

namespace EmployeeManagementSystem.Tests.EmployeeManagementSystem.Services.Tests.Services.Profiles
{
    public class RoleProfileTests
    {
        private readonly IMapper _mapper;

        private readonly Guid RoleId = new Guid("388a37ae-4040-4961-a840-a728a2b95ac9");
        private const string RoleName = "Cleaner";

        public RoleProfileTests()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<RoleProfile>();
            });

            _mapper = configuration.CreateMapper();
        }

        [Fact]
        public void RoleProfile_Should_Correctly_Map_RoleItem()
        {
            //Arrange
            var coreRole = new Role()
            {
                Id = RoleId,
                Name = RoleName
            };

            var roleItemResponse = new RoleItem()
            {
                Id = RoleId,
                Name = RoleName
            };

            //Act
            var result = _mapper.Map<RoleItem>(coreRole);

            //Assert
            result.Should().BeEquivalentTo(roleItemResponse);
        }
    }
}
