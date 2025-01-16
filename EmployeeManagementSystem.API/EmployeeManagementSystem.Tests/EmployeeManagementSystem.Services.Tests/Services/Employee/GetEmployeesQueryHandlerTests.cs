using AutoMapper;
using EmployeeManagementSystem.DataAccess.Entities;
using EmployeeManagementSystem.DataAccess.Repositories.Employee;
using EmployeeManagementSystem.Services.Employee.GetEmployees;
using FakeItEasy;
using Xunit;
using EmployeeManagementSystem.Services.Employee;
using FluentAssertions;

namespace EmployeeManagementSystem.Tests.EmployeeManagementSystem.Services.Tests.Services.Employees
{
    public class GetEmployeesQueryHandlerTests
    {
        private readonly GetEmployeesQueryHandler _fakeHandler;
        private readonly IMapper _fakeMapper;
        private readonly IEmployeeRepository _fakeEmployeeRepository;

        private readonly Guid EmployeeId = new Guid("388a37ae-4040-4961-a840-a728a2b95ac7");
        private const string EmployeeName = "David Peterson";

        public GetEmployeesQueryHandlerTests()
        {
            _fakeMapper = A.Fake<IMapper>();
            _fakeEmployeeRepository = A.Fake<IEmployeeRepository>();
            _fakeHandler = new GetEmployeesQueryHandler(_fakeEmployeeRepository, _fakeMapper);
        }

        [Fact]
        public async Task Handler_Should_Return_Expected_Object()
        {
            //Arrange
            var getQuery = new GetEmployeesQuery();

            var expectedGetQueryResponse = new GetEmployeesQueryHandlerResponse
            {
                Items = new List<EmployeeItem>()
                {
                    new EmployeeItem
                    {
                        Id = EmployeeId,
                        Name = EmployeeName
                    }
                }
            };

            A.CallTo(() => _fakeEmployeeRepository.GetEmployees())
                    .Returns(new List<Employee>()
                    {
                         new Employee()
                         {
                           Id = EmployeeId,
                           Name = EmployeeName
                         }
                    });

            A.CallTo(() => _fakeMapper.Map<IEnumerable<EmployeeItem>>(A<IEnumerable<Employee>>
                                       .That
                                       .Matches(x => x.Any(q =>
                                       q.Id == EmployeeId && q.Name == EmployeeName))))
               .Returns(new List<EmployeeItem>()
                {
                     new EmployeeItem
                    {
                        Id = EmployeeId,
                        Name = EmployeeName
                    }
                });

            //Act
            var result = await _fakeHandler.Handle(getQuery, default);

            //Assert
            A.CallTo(() => _fakeEmployeeRepository.GetEmployees())
                .MustHaveHappenedOnceExactly();

            result
                .Should()
                .BeOfType<GetEmployeesQueryHandlerResponse>()
                .Which
                .Should()
                .BeEquivalentTo(expectedGetQueryResponse);
        }

        [Fact]
        public async Task Handler_Should_Return_Null_When_Employees_Response_From_Database_Is_Empty()
        {
            //Arrange
            var getQuery = new GetEmployeesQuery();


            A.CallTo(() => _fakeEmployeeRepository.GetEmployees())
                    .Returns(new List<Employee>()
                    { });

            //Act
            var result = await _fakeHandler.Handle(getQuery, default);

            //Assert
            A.CallTo(() => _fakeEmployeeRepository.GetEmployees())
                .MustHaveHappened();

            result
                .Should()
                .BeNull();
        }
    }
}
