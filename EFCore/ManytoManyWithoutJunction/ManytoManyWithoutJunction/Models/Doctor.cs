using System.ComponentModel.DataAnnotations;

namespace ManytoManyWithoutJunction.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Specialty { get; set; }
        public ICollection<Patient>? Patients { get; set; }
    }
}
