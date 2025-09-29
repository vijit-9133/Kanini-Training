using Microsoft.EntityFrameworkCore;
using AssignmentAPI.Models;

namespace AssignmentAPI.Data
{
    public class EmpProContext : DbContext
    {
        public EmpProContext() { }
        public EmpProContext(DbContextOptions<EmpProContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasIndex(p => p.ProjectCode)
                    .IsUnique();

                entity.Property(p => p.Budget);

                entity.HasData(
                    new Project
                    {
                        ProjectId = 1,
                        ProjectCode = "PRJ001",
                        ProjectName = "Fusion Core Development",
                        StartDate = new DateTime(2023, 10, 15),
                        EndDate = new DateTime(2024, 6, 30),
                        Budget = 500000.00M
                    },
                    new Project
                    {
                        ProjectId = 2,
                        ProjectCode = "PRJ002",
                        ProjectName = "Legacy System Migration",
                        StartDate = new DateTime(2024, 1, 5),
                        EndDate = null, 
                        Budget = 150000.50M
                    },
                    new Project
                    {
                        ProjectId = 3,
                        ProjectCode = "PRJ003",
                        ProjectName = "Mobile App Revamp",
                        StartDate = new DateTime(2024, 5, 20),
                        EndDate = null,
                        Budget = 75000.00M
                    }
                );
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.EmployeeCode)
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .IsUnique();

                entity.Property(e => e.Salary);
                   

                entity.HasOne(e => e.Project)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(e => e.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasData(
                    new Employee
                    {
                        EmployeeId = 101,
                        EmployeeCode = "EMP101",
                        FullName = "Alice Johnson",
                        Email = "alice.j@corp.com",
                        Designation = "Lead Developer",
                        Salary = 95000.00M,
                        ProjectId = 1 
                    },
                    new Employee
                    {
                        EmployeeId = 102,
                        EmployeeCode = "EMP102",
                        FullName = "Bob Smith",
                        Email = "bob.s@corp.com",
                        Designation = "Project Manager",
                        Salary = 110000.00M,
                        ProjectId = 2 
                    },
                    new Employee
                    {
                        EmployeeId = 103,
                        EmployeeCode = "EMP103",
                        FullName = "Charlie Brown",
                        Email = "charlie.b@corp.com",
                        Designation = "UI/UX Designer",
                        Salary = 72000.00M,
                        ProjectId = 3 
                    }
                );
            });
        }
    }
}
