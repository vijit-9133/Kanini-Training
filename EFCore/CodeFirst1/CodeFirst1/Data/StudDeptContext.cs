using CodeFirst1.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst1.Data
{
    public class StudDeptContext : DbContext
    {
        public StudDeptContext(DbContextOptions<StudDeptContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<CourseTrainer> CourseTrainers { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Call the base method

            // Correct HasKey definitions
            modelBuilder.Entity<Student>().HasKey(s => s.StudentId);
            modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.StudentId, sc.CourseId });
            modelBuilder.Entity<CourseTrainer>().HasKey(ct => new { ct.CourseId, ct.TrainerId });

            // Seed data for all models
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, Name = "Virendra", Age = 20, City = "Mumbai", DepartmentId = 1, Fees = 100000 },
                new Student { StudentId = 2, Name = "Prathamesh", Age = 22, City = "Pune", DepartmentId = 2, Fees = 90000 },
                new Student { StudentId = 3, Name = "Vijit", Age = 21, City = "Bangalore", DepartmentId = 3, Fees = 110000 }
            );
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "Computer Science" },
                new Department { DepartmentId = 2, DepartmentName = "Electronics and Telecommunication" },
                new Department { DepartmentId = 3, DepartmentName = "Mechanical Engineering" }
            );
            // You MUST include these as the join tables reference them
            modelBuilder.Entity<Trainer>().HasData(
                new Trainer { TrainerId = 1, TrainerName = "Priya Sharma" },
                new Trainer { TrainerId = 2, TrainerName = "Rahul Verma" },
                new Trainer { TrainerId = 3, TrainerName = "Sanjay Gupta" }
            );
            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 101, CourseName = "Advanced C# and .NET" },
                new Course { CourseId = 102, CourseName = "Machine Learning with Python" },
                new Course { CourseId = 103, CourseName = "Data Structures & Algorithms" }
            );

            // Seed data for join tables
            modelBuilder.Entity<StudentCourse>().HasData(
                new StudentCourse { StudentId = 1, CourseId = 101 },
                new StudentCourse { StudentId = 2, CourseId = 102 },
                new StudentCourse { StudentId = 3, CourseId = 101 }
            );
            modelBuilder.Entity<CourseTrainer>().HasData(
                new CourseTrainer { CourseId = 101, TrainerId = 1 },
                new CourseTrainer { CourseId = 102, TrainerId = 2 },
                new CourseTrainer { CourseId = 103, TrainerId = 3 }
            );

            // Correct and single check constraint definition
            modelBuilder.Entity<Student>()
                .HasCheckConstraint("CK_Stud_Age", "Age >= 18 AND Age <= 30");
        }
    }
}