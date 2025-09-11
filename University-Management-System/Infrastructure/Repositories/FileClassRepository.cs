using Newtonsoft.Json;
using University_Management_System.Domain.Contracts.Repository_Contracts;
using University_Management_System.Domain.Entities;

namespace University_Management_System.Infrastructure.Repositories;


public class FileClassRepository : IClassRepository
{
    private readonly string _path = @"D:\Class.json";
    private readonly IUserRepository _userRepository;
    private readonly ICourseRepository _courseRepository;

    public FileClassRepository(IUserRepository userRepository, ICourseRepository courseRepository)
    {
        _userRepository = userRepository;
        _courseRepository = courseRepository;
    }

    private List<Class> LoadFile()
    {
        if (!File.Exists(_path))
            return new List<Class>();

        var json = File.ReadAllText(_path);
        var classes = JsonConvert.DeserializeObject<List<Class>>(json, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            TypeNameHandling = TypeNameHandling.All
        }) ?? new List<Class>();


        foreach (var cl in classes)
        {
            if (cl.Teacher != null)
            {
                var teacher = _userRepository.GetUserById(cl.Teacher.Id) as Teacher;
                cl.SetTeacher(teacher ?? cl.Teacher); 
            }

            if (cl.Course != null)
            {
                var course = _courseRepository.GetById(cl.Course.Id);
                cl.SetCourse(course ?? cl.Course); 
            }

            cl.SetStudents(cl.Students ?? new List<Student>());
            cl.SetSchedules(cl.Schedules ?? new List<ClassSchedule>());
        }

        return classes;
    }

    private void SaveFile(List<Class> classes)
    {
        var settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            TypeNameHandling = TypeNameHandling.Auto,
            TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
            Formatting = Formatting.Indented
        };

        var json = JsonConvert.SerializeObject(classes, settings);
        File.WriteAllText(_path, json);
    }

    public Class Add(Class courseClass)
    {
        var list = LoadFile();
        courseClass.Id = GetMaxId() + 1;
        list.Add(courseClass);
        SaveFile(list);
        return courseClass;
    }

    public void Update(Class courseClass)
    {
        var list = LoadFile();
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].Id == courseClass.Id)
            {
                list[i].SetClassName(courseClass.ClassName);
                list[i].SetTeacher(courseClass.Teacher);
                list[i].SetCourse(courseClass.Course);
                list[i].SetStudents(courseClass.Students);
                list[i].SetSchedules(courseClass.Schedules);
                list[i].SetTime(courseClass.StartTime, courseClass.EndTime);
                list[i].SetCapacity(courseClass.Capacity);
                break;
            }
        }
        SaveFile(list);
    }

    public void Delete(int id)
    {
        var list = LoadFile();
        list.RemoveAll(c => c.Id == id);
        SaveFile(list);
    }

    public Class? GetById(int id)
    {
        return LoadFile().FirstOrDefault(c => c.Id == id);
    }

    public List<Class> GetAll()
    {
        return LoadFile();
    }

    public List<Class> GetByCourseId(int courseId)
    {
        return LoadFile().Where(c => c.Course?.Id == courseId).ToList();
    }

    public List<Class> GetByTeacherId(int teacherId)
    {
        return LoadFile().Where(c => c.Teacher?.Id == teacherId).ToList();
    }

    public int GetMaxId()
    {
        return LoadFile().DefaultIfEmpty(new Class()).Max(c => c?.Id ?? 0);
    }
}