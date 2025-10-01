using System.ComponentModel.DataAnnotations;

namespace ManytoManyWithoutJunction.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Doctor>? Doctors { get; set; } 
    }
}
