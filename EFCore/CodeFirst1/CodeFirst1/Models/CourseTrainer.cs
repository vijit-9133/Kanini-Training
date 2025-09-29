using CodeFirst1.Models;

public class CourseTrainer
{
    public int CourseId { get; set; }
    public Course Course { get; set; }

    public int TrainerId { get; set; }
    public Trainer Trainer { get; set; }
}