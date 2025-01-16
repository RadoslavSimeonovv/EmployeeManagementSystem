namespace EmployeeManagementSystem.API.Models.Employee
{
    public class GetEmployeesResponse
    {
        public IEnumerable<EmployeeModelResponse> Items { get; set; }
    }
}
