

namespace PTMKTestTask.Persistence
{
    public interface IEmployeeServise
    {
        public Task AddEmployeeAsync(Employee newEmployee);
        public Task AddEmployeeListAsync(List<Employee> employees);
        public Task<List<Employee>> GetNoRepitEmployees();
        public Task<List<Employee>> GetEmployeeWhereFirstLetterF();
        public Task CreateDBAsync(); 
    }
}
