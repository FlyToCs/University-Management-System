namespace University_Management_System.Domain.Entities;

public class Course
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int Unit { get; private set; }
    public string? Description { get; private set; }

    public List<Course> Prerequisite { get; private set; } 

    public Course(int id, string name, int unit, string description)
    {
        Id = id;
        Name = name;
        Unit = unit;
        Description = description;
        Prerequisite = new();
    }


}