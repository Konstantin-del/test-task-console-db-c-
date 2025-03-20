using Bogus;
using PTMKTestTask.Persistence;

namespace PTMKTestTask.Application;

public class DataGenerator
{
    public const int NumberOfEmployees = 5;

    private static Faker<EmployeeModel> GetEmployeeGenerator()
    {
        return new Faker<EmployeeModel>()
          .RuleFor(u => u.Gender, f => f.PickRandom<Gender>())
          .RuleFor(u => u.FullName, (f, u) =>
          {
              Bogus.DataSets.Name.Gender gender = (Bogus.DataSets.Name.Gender)u.Gender;
              var result = f.Name.LastName(gender);
              result += $" {f.Name.FirstName(gender)}";
              string end = u.Gender == Gender.Female ? "na" : "ich";
              result += $" {f.Name.FirstName()}{end}";
              return result;
          })
          .RuleFor(u => u.Birthday, f => f.Date.Past(60, DateTime.Now.AddYears(-20)).Date);
    }

    private static Faker<EmployeeModel>GetEmployeeGeneratorLastNameWithF()
    {
        return new Faker<EmployeeModel>()
        .RuleFor(u => u.Gender, f => Gender.Male)
        .RuleFor(u => u.FullName, (f, u) =>
        {
            Bogus.DataSets.Name.Gender gender = (Bogus.DataSets.Name.Gender)u.Gender;
            var result = f.Name.LastName(gender);
            result = $"F{result.Substring(1)}";
            result += $" {f.Name.FirstName(gender)}";
            string end = u.Gender == Gender.Female ? "na" : "ich";
            result += $" {f.Name.FirstName()}{end}";
            return result;
        })
        .RuleFor(u => u.Birthday, f => f.Date.Past(60, DateTime.Now.AddYears(-20)).Date);
    }

    public static List<EmployeeModel> InitBogusData()
    {
        var employeeGenerator = GetEmployeeGenerator();
        return  employeeGenerator.Generate(NumberOfEmployees);
    }

    public static List<EmployeeModel> InitBogusDataLastNameWithF()
    {
        var employeeGenerator = GetEmployeeGeneratorLastNameWithF();
        return employeeGenerator.Generate(NumberOfEmployees);
    }
}
