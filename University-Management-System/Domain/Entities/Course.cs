namespace University_Management_System.Domain.Entities;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Unit { get; set; }


    public List<Course> Prerequisites { get; private set; } = new();

    public Course(int id, string name, string description, int unit)
    {
        Id = id;
        Name = name;
        Description = description;
        Unit = unit;
    }

    public void AddPrerequisite(Course prerequisite)
    {
        if (Prerequisites.Any(p => p.Id == prerequisite.Id))
            throw new Exception("This prerequisite already exists.");

        Prerequisites.Add(prerequisite);
    }
}