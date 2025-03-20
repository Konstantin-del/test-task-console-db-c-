

using Microsoft.EntityFrameworkCore;

namespace PTMKTestTask.Persistence;

public class EmployeeRepository
{
    private readonly EmployeeContext _context;
    private readonly Employee _newEmployee;
    public EmployeeRepository()
    {
        _context = new();
    }


    public async Task AddEmployeeAsync(Employee newEmployee)
    {
        var employee = await _context.Employees.AddAsync(newEmployee);
        await _context.SaveChangesAsync();
        Console.WriteLine("employee added");
    }

    public async Task AddEmployeeListAsync(List<Employee> employees)
    {
        await _context.Employees.AddRangeAsync(employees);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Employee>> GetNoRepitEmployees()
    {
        return await _context.Employees.GroupBy(m => new { m.FullName, m.Birthday }).Select(e => e.First()).ToListAsync();
    }

    public async Task CreateDBAsync()
    {
        try
        {
            await _context.Database.EnsureCreatedAsync();
            Console.WriteLine("db is created");
        }
        catch
        {
            Console.WriteLine("Create db failed");
        }
    }
}
