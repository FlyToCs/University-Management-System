using Newtonsoft.Json;
using University_Management_System.Domain.Contracts.Repository_Contracts;
using University_Management_System.Domain.Entities;

namespace University_Management_System.Infrastructure.Repositories;

public class FileCourseRepository : ICourseRepository
{
    private readonly string _path = @"D:\Course.json";

    private List<Course> LoadFile()
    {
        if (!File.Exists(_path))
        {
            return new List<Course>();
        }

        var json = File.ReadAllText(_path);
        var courses = JsonConvert.DeserializeObject<List<Course>>(json, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            TypeNameHandling = TypeNameHandling.All
        }) ?? new List<Course>();

        return courses;
    }

    private void SaveFile(List<Course> courses)
    {
        var settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
            Formatting = Formatting.Indented
        };

        var json = JsonConvert.SerializeObject(courses, settings);
        File.WriteAllText(_path, json);
    }





    public Course Add(Course course)
    {
        var list = LoadFile();

        // 👇 همینجا Id رو تولید کن
        course.Id = GetMaxId() + 1;

        list.Add(course);
        SaveFile(list);
        return course;
    }



    public void Update(Course course)
    {
        var list = LoadFile();
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].Id == course.Id)
            {
                list[i] = course;
                break;
            }
        }
        SaveFile(list);
    }

    public void Delete(int id)
    {
        var list = LoadFile();
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].Id == id)
            {
                list.RemoveAt(i);
                break;
            }
        }
        SaveFile(list);
    }

    public Course? GetById(int id)
    {
        var list = LoadFile();
        foreach (var course in list)
        {
            if (course.Id == id)
                return course;
        }
        return null;
    }

    public List<Course> GetAll()
    {
        return LoadFile();
    }



    public int GetMaxId()
    {
        int max = 0;
        foreach (var course in LoadFile())
        {
            if (course.Id > max)
                max = course.Id;
        }
        return max;
    }

}