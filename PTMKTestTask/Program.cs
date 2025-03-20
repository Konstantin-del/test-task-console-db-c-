﻿using PTMKTestTask.Persistence;
using PTMKTestTask.Application;

namespace PTMKTestTask;

internal class Program
{
    private static EmployeeService _service = new();
    static async Task Main(string[] args)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        
        int a = 0;
        
        while (a>4 || a<=0) 
        {
            Console.WriteLine("Hello! enter number \n" +
                "1: to create db \n" +
                "2: to add employee \n" +
                "3: get sorted employees \n" +
                "4: add 1000000 employees + 100 employee is name start with f"
            );

            bool isParse = int.TryParse(Console.ReadLine(), out var number);
            if (isParse) a = number;
            else Console.WriteLine("inwalid parse");
        }

        Console.WriteLine($"you enter {a}");

        switch (a)
        {
            case 1:
                await _service.CreateDBAsync();
                break;
            case 2:
                var employee = CreateEmployee();
                await _service.AddEmployeeAsync(employee);
                var age = _service.CalculateAge(employee.Birthday);
                Console.WriteLine($"age: {age}");
                break;
            case 3:
                await _service.GetNoRepitEmployees();
                break;
            case 4:
                await _service.AddFakeEmployeesLastNameWithF();
                await _service.AddFakeEmployees();
                break;
            default:
                Console.WriteLine("value is no valid");
                break;
        }
    }
    internal static EmployeeModel CreateEmployee()
    {
        bool isWhile = true;
        var newEmployee = new EmployeeModel();

        while (isWhile)
        {
            if (newEmployee.FullName is null)
            {
                Console.WriteLine("enter full name");
                var fullName = Console.ReadLine() ?? "";
                if (fullName.Length == 0) continue;
                newEmployee.FullName = fullName;
            }
            
            Console.WriteLine("enter your birthday, format: MM/dd/yyyy");
            var dateString = Console.ReadLine();
            DateTime parsedDate;
            bool isValidDate = DateTime.TryParse(dateString, out parsedDate);
            if (!isValidDate) 
            {
                Console.WriteLine("inwalid parse, enter again");
                continue;
            }
            newEmployee.Birthday = parsedDate;

            string gender="";
            while(gender != "w" && gender != "m")
            {
                Console.WriteLine("enter your gender: w or m");
                gender = Console.ReadLine();
            }
            newEmployee.Gender = gender == "w" ? Gender.Female : Gender.Male;
            isWhile = false;
        }
        return newEmployee;
    }
}
