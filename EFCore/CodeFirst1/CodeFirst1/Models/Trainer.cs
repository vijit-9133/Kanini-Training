using System.ComponentModel.DataAnnotations;

namespace CodeFirst1.Models
{
    public class Trainer
    {
        [Key]
        public int TrainerId { get; set; }

        [Required]
        [StringLength(50)]
        public string TrainerName { get; set; }

        // Navigation property for the many-to-many relationship
        public ICollection<CourseTrainer> CourseTrainers { get; set; }
    }
}