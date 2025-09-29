using System.ComponentModel.DataAnnotations;

namespace TheCourseHubADO.Models
{
    public class Student
    {
        public int StudId { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters.")]
        public string Fname { get; set; }

        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters.")]
        public string Lname { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enrollment Date is required.")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }

        [StringLength(20, ErrorMessage = "City cannot be longer than 20 characters.")]
        public string City { get; set; }

        [StringLength(20, ErrorMessage = "Country cannot be longer than 20 characters.")]
        public string Country { get; set; }

        public int? ActiveCourseCount { get; set; }
    }
}
