using Newtonsoft.Json;
using University_Management_System.Domain.Contracts.Repository_Contracts;
using University_Management_System.Domain.Entities;

namespace University_Management_System.Infrastructure.Repositories;

public class FileUserRepository : IUserRepository
{
    private readonly string _path = @"D:\User.json";

    private List<User> LoadFile()
    {
        if (!File.Exists(_path)) return new List<User>();

        var json = File.ReadAllText(_path);
        var settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        var users = JsonConvert.DeserializeObject<List<User>>(json, settings) ?? new List<User>();
        return users;
    }

    private void SaveFile(List<User> users)
    {
        var settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto, 
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
            Formatting = Formatting.Indented
        };

        var json = JsonConvert.SerializeObject(users, settings);
        File.WriteAllText(_path, json);
    }

    public User AddUser(User user)
    {

        var userList = LoadFile();
        userList.Add(user);
        SaveFile(userList);
        return user;
    }

    public User GetUserById(int id)
    {
        var userList = LoadFile();
        foreach (var user in userList)
        {
            if (user.Id == id)
            {
                return user;
            }
        }
        return null!;
    }

    public List<User> GetAllUsers()
    {
        return LoadFile();
    }

    public void DeleteUser(User user)
    {
        var userList = LoadFile();
        for (int i = 0; i < userList.Count; i++)
        {
            if (userList[i].Id == user.Id)
            {
                userList.Remove(userList[i]);
                break;
            }
        }
        SaveFile(userList);
    }

    public void UpdateUser(User user)
    {
        var userList = LoadFile();
        for (int i = 0; i < userList.Count; i++)
        {
            if (userList[i].Id == user.Id)
            {
                userList[i] = user;
                break;
            }
        }
        SaveFile(userList);
    }

    public int GetMaxId()
    {
        int max = 0;
        foreach (var user in LoadFile())
        {
            if (user.Id > max)
            {
                max = user.Id;
            }
        }

        return max;
    }
}