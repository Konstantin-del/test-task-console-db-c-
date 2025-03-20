

using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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

    public async Task<List<Employee>> GetEmployeeWhereFirstLetterF()
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        var result = await _context.Employees.Where(e => e.FullName.StartsWith("F") && e.Gender == Gender.Male).ToListAsync();
        stopWatch.Stop();
        Console.WriteLine(stopWatch.Elapsed);
        return result;
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
