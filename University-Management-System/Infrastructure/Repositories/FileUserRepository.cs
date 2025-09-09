using Newtonsoft.Json;
using University_Management_System.Domain.Contracts.Repository_Contracts;
using University_Management_System.Domain.Entities;

namespace University_Management_System.Infrastructure.Repositories;

public class FileUserRepository : IUserRepository
{
    private readonly string _path = @"D:\User.json";

    private List<User> LoadFile()
    {
        var json = File.ReadAllText(_path);
        List<User> users = JsonConvert.DeserializeObject<List<User>>(json)?? new List<User>();
        return users;
    }

    private void SaveFile(List<User> users)
    {
        var json = JsonConvert.SerializeObject(users, Formatting.Indented, new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.All
        });
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
        return new User();
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
}