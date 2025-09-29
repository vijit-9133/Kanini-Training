using System.ComponentModel.DataAnnotations;

namespace CodeFirst1.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        [StringLength(50)]
        public string CourseName { get; set; }

        // Navigation properties for many-to-many relationships
        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<CourseTrainer> CourseTrainers { get; set; }
    }

}
