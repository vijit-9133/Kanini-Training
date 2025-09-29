using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentAPI.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(8)]
        [StringLength(8)]
        [Column(TypeName = "varchar(8)")]
        public string EmployeeCode { get; set; }

        [Required]
        [MaxLength(150)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress] 
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Designation { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")] 
        public decimal Salary { get; set; }
        public int ProjectId { get; set; }

        // Navigation Property - Reference to Project
        public virtual Project Project { get; set; }
    }

}
