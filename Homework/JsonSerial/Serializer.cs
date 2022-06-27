using Homework.Models;
using System.Text.Json;
using System.Collections.Generic;
namespace Homework.JsonSerial
{
    public static class Serializer
    {
        public static List<User> ReadUser()
        {
            List<User>? Users = new List<User>()
            {
                new User(){ Id = 1, Name ="Иван", Surname = "Иванов", BirthDate = new DateTime(2000,1,1)}
            };
            using (FileStream fs = new FileStream("users.json", FileMode.OpenOrCreate))
            {
                Users = JsonSerializer.Deserialize<List<User>>(fs);
            }
            return Users;
        }
        public static void WriteUser(List<User> users)
        {
            using (FileStream fs = new FileStream("users.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, users);
            }
        }


        public static List<Service> ReadService()
        {
            List<Service>? Services;
            using (FileStream fs = new FileStream("services.json", FileMode.OpenOrCreate))
            {
                Services = JsonSerializer.Deserialize<List<Service>>(fs);
            }
            return Services;
        }
        public static void WriteService(List<Service> services)
        {
            using (FileStream fs = new FileStream("services.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, services);
            }
        }
    }
}
