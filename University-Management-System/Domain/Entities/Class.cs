namespace University_Management_System.Domain.Entities;

public class Class
{
    public int Id { get; set; }
    public string ClassName { get; set; }
    public Teacher Teacher { get; set; }
    //public List<Enrollment> Enrollments { get; set; }
    public Course Course { get; set; }
    public int Capacity { get; private set; }
    public List<ClassSchedule> Schedules { get; private set; }
    public List<Student> Students { get; private set; }

    public DateTime? StartTime { get; private set; }
    public DateTime? EndTime { get; private set; }

    public Class(int id, string className, Teacher teacher,Course course,List<Student> students, DateTime startTime, DateTime endTime)
    {
        Id = id;
        ClassName = className;
        Teacher = teacher;
        Course = course;
        Students = students;
        StartTime = startTime;
        EndTime = endTime;
    }

    public void AddSchedule(ClassSchedule schedule)
    {
        foreach (var existing in Schedules)
        {
            if (existing.ConflictsWith(schedule))
            {
                throw new InvalidOperationException("Schedule conflicts with existing class times");
            }
        }

        Schedules.Add(schedule);
    }



}