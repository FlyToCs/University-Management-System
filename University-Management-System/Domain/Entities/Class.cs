namespace University_Management_System.Domain.Entities;

public class Class
{
    public int Id { get; set; }
    public string ClassName { get; set; }
    public Teacher Teacher { get; set; }
    public List<Enrollment> Students { get; set; }
    public Course Course { get; set; }
    public DateTime? StartTime { get; private set; }
    public DateTime? EndTime { get; private set; }

    public Class(int id, string className, Teacher teacher, DateTime startTime, DateTime endTime)
    {
        Id = id;
        ClassName = className;
        Teacher = teacher;
        Students = new List<Enrollment>();
        StartTime = startTime;
        EndTime = endTime;
    }
}