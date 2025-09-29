using System;
using System.Collections.Generic;

namespace Assignment1.Models;

public partial class Enrollment
{
    public int EnrollmentId { get; set; }

    public string CourseTitle { get; set; } = null!;

    public decimal? Grade { get; set; }

    public int? StudentId { get; set; }

    public virtual Student? Student { get; set; }
}
