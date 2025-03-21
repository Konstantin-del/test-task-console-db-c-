
using PTMKTestTask.Persistence;

namespace PTMKTestTask.Application;

public class EmployeeService 
{
    private readonly EmployeeRepository _repository;
    public EmployeeService()
    {
        _repository = new();
    }

    public async Task AddEmployeeAsync(EmployeeModel employee)
    {
        Employee newEmployee = new();
        newEmployee.Birthday = employee.Birthday;
        newEmployee.FullName = employee.FullName;
        newEmployee.Gender = employee.Gender;
        await _repository.AddEmployeeAsync(newEmployee);
    }

    public async Task AddFakeEmployees()
    {
        int count = 5;
        while (count<=1000000)
        {
            var employees = DataGenerator.InitBogusData();
            
            List<Employee> list = new();
            foreach (var employee in employees)
            {
                Employee newEmployee = new();
                newEmployee.Birthday = employee.Birthday;
                newEmployee.FullName = employee.FullName;
                newEmployee.Gender = employee.Gender;
                list.Add(newEmployee);
            }
            await _repository.AddEmployeeListAsync(list);
            count += 5;
        }
    }

    public async Task AddFakeEmployeesLastNameWithF()
    {
        int count = 5;
        while (count <= 100)
        {
            var employees = DataGenerator.InitBogusDataLastNameWithF();

            List<Employee> list = new();
            foreach (var employee in employees)
            {
                Employee newEmployee = new();
                newEmployee.Birthday = employee.Birthday;
                newEmployee.FullName = employee.FullName;
                newEmployee.Gender = employee.Gender;
                list.Add(newEmployee);
            }
            await _repository.AddEmployeeListAsync(list);
            count += 5;
        }
    }

    public async Task GetNoRepitEmployees()
    {
        var result = await _repository.GetNoRepitEmployees();
        foreach (var item in result)
        {
            var age = CalculateAge(item.Birthday);
            Console.WriteLine($"{item.FullName} {item.Birthday.ToString("yyyy-MM-dd")} {item.Gender} {age}");
        } 
    }

    public async Task CreateDBAsync()
    {
        await _repository.CreateDBAsync();
    }

    public int CalculateAge(DateTime birthDate)
    {
        DateTime currentDate = DateTime.Now.Date;
        int age = currentDate.Year - birthDate.Year;
        if (currentDate.Month < birthDate.Month ||
            (currentDate.Month == birthDate.Month && currentDate.Day < birthDate.Day))
        {
            age--;
        }
        return age;
    }

    public async Task GetEmployeeWhereFirstLetterF()
    {
        var employees = await _repository.GetEmployeeWhereFirstLetterF();

        //foreach (var employee in employees)
        //{
        //    Console.WriteLine($"{employee.FullName}");
        //}
    }

}
