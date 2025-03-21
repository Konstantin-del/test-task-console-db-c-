
namespace PTMKTestTask.Application
{
    public interface IEmployeeService
    {
        public Task AddEmployeeAsync(EmployeeModel employee);
        public Task AddFakeEmployees();
        public Task AddFakeEmployeesLastNameWithF();
        public Task GetNoRepitEmployees();
        public Task CreateDBAsync();
        public int CalculateAge(DateTime birthDate);
        public Task GetEmployeeWhereFirstLetterF();
    }
}
