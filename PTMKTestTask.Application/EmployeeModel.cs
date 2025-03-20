using PTMKTestTask.Persistence;

namespace PTMKTestTask.Application;

public class EmployeeModel
{
    public string FullName { get; set; }

    public DateTime Birthday { get; set; }

    public Gender Gender { get; set; }
}
