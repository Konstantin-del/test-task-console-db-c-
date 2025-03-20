using Microsoft.EntityFrameworkCore;

namespace PTMKTestTask.Persistence;

public class EmployeeContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=fred;Database=postgres;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .Property(s => s.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<Employee>()
            .Property(s => s.FullName)
            .IsRequired()
            .HasMaxLength(55);
        modelBuilder.Entity<Employee>()
            .Property(s => s.Birthday)
            .IsRequired();
        modelBuilder.Entity<Employee>()
            .Property(s => s.Gender)
            .IsRequired();
    }
}
