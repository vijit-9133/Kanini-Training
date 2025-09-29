using CodeFirst1.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class Student
{
    [Key]
    public int StudentId { get; set; }

    [StringLength(40, MinimumLength = 3, ErrorMessage = "Name should be atleast 3 characters long")]
    [Required]
    public string Name { get; set; }

    public int Age { get; set; }

    [StringLength(25)]
    public string? City { get; set; }

    // Correct Foreign Key property for Department
    public int DepartmentId { get; set; }

    [Precision(8, 2)]
    [Range(75000, 150000, ErrorMessage = "Fees should be between 75000 and 150000")]
    public decimal Fees { get; set; }

    // Navigation property to the Department
    public Department? Department { get; set; }

    // Navigation property for many-to-many relationship
    public ICollection<StudentCourse>? StudentCourses { get; set; }
}