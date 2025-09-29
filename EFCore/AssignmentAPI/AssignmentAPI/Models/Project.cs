using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentAPI.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        [MaxLength(10)]
        [StringLength(10)] 
        [Column(TypeName = "varchar(10)")] 
        public string ProjectCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProjectName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; } 

        [Required]
        [Column(TypeName = "decimal(18, 2)")] 
        public decimal Budget { get; set; }

        // Navigation Property - List of Employees
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
