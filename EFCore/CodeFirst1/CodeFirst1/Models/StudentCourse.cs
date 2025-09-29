﻿using CodeFirst1.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class StudentCourse
{
    public int StudentId { get; set; }
    public Student Student { get; set; }

    public int CourseId { get; set; }
    public Course Course { get; set; }
}