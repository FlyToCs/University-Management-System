using Newtonsoft.Json;

namespace University_Management_System.Domain.Entities;

public class Class
{
    public int Id { get; set; }
    [JsonProperty]
    public string ClassName { get; private set; }
    [JsonProperty]
    public Teacher Teacher { get; private set; }
    [JsonProperty]
    public Course Course { get; private set; }
    [JsonProperty]
    public int Capacity { get; private set; }
    [JsonProperty]
    public List<ClassSchedule> Schedules { get; private set; } = new();
    [JsonProperty]
    public List<Student> Students { get; private set; } = new();
    [JsonProperty]
    public DateTime? StartTime { get; private set; }
    [JsonProperty]
    public DateTime? EndTime { get; private set; }

    public Class() { }

    public Class(int id, string className, Teacher teacher, Course course, int capacity)
    {
        Id = id;
        ClassName = className;
        Teacher = teacher;
        Course = course;
        Capacity = capacity;
    }

    [JsonConstructor]
    public Class(int id, string className, Teacher teacher, Course course, List<Student> students, DateTime startTime, DateTime endTime, int capacity)
    {
        Id = id;
        ClassName = className;
        Teacher = teacher;
        Course = course;
        Students = students ?? new List<Student>();
        StartTime = startTime;
        EndTime = endTime;
        Capacity = capacity;
    }


    public void SetClassName(string name) => ClassName = name;
    public void SetTeacher(Teacher teacher) => Teacher = teacher;
    public void SetCourse(Course course) => Course = course;
    public void SetCapacity(int capacity)
    {
        if (capacity < Students.Count)
            throw new Exception("Capacity cannot be less than current number of students");
        Capacity = capacity;
    }
    public void SetTime(DateTime? start, DateTime? end)
    {
        if (end <= start)
            throw new Exception("End time must be after start time");
        StartTime = start;
        EndTime = end;
    }
    public void SetSchedules(List<ClassSchedule> schedules) => Schedules = schedules ?? new();
    public void SetStudents(List<Student> students) => Students = students ?? new();


    public void AddSchedule(ClassSchedule schedule)
    {
        foreach (var existing in Schedules)
        {
            if (existing.ConflictsWith(schedule))
                throw new InvalidOperationException("Schedule conflicts with existing class times");
        }
        Schedules.Add(schedule);
    }


    public void EnrollStudent(Student student)
    {
        if (Students.Count >= Capacity)
            throw new Exception("Class is full");

        if (Students.Any(s => s.Id == student.Id))
            throw new Exception("Student is already enrolled in this class");

        Students.Add(student);
        Capacity--; 
    }
    }
