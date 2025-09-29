using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CodeFirst1.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(50)]
        public string DepartmentName { get; set; }

        // Navigation property for the students in this department
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}