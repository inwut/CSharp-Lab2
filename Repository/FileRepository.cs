using Lab2.Models;
using Lab2.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab2.Repository
{
    internal class FileRepository 
    {
        private static readonly string BaseFolder = Path.Combine("C:\\Users\\Lenovo\\Desktop\\ооп\\Lab2\\", "UsersStorage");
        public FileRepository()
        {
            if (!Directory.Exists(BaseFolder))
            {
                Directory.CreateDirectory(BaseFolder);
                UsersCreator.getUsers().ForEach(u => AddAsync(u));
            }
        }

        public async Task AddAsync(DBUser dbUser)
        {
            var stringObj = JsonSerializer.Serialize(dbUser);

            using (StreamWriter sw = new StreamWriter(Path.Combine(BaseFolder, dbUser.Email), false))
            {
                await sw.WriteAsync(stringObj);
            }
        }

        public void Delete(string email)
        {
           if(File.Exists(Path.Combine(BaseFolder, email)))
           {
                File.Delete(Path.Combine(BaseFolder, email));
           }
           else
           {
                throw new Exceptions.PersonNotFoundException("Person with email " + email + " doesn't exist!");
           }
        }

        public async Task<DBUser> GetAsync(string email)
        {
            string stringObj = null;
            string filePath = Path.Combine(BaseFolder, email);

            if (!File.Exists(filePath))
                return null;

            using (StreamReader sw = new StreamReader(filePath))
            {
                stringObj = await sw.ReadToEndAsync();
            }

            return JsonSerializer.Deserialize<DBUser>(stringObj);
        }

        public async Task<List<DBUser>> GetAllAsync()
        {
            var res = new List<DBUser>();
            foreach (var file in Directory.EnumerateFiles(BaseFolder))
            {
                string stringObj = null;

                using (StreamReader sw = new StreamReader(file))
                {
                    stringObj = await sw.ReadToEndAsync();
                }

                res.Add(JsonSerializer.Deserialize<DBUser>(stringObj));
            }

            return res;
        }

        public List<DBUser> GetAll()
        {
            var res = new List<DBUser>();
            foreach (var file in Directory.EnumerateFiles(BaseFolder))
            {
                string stringObj = null;

                using (StreamReader sw = new StreamReader(file))
                {
                    stringObj = sw.ReadToEnd();
                }

                res.Add(JsonSerializer.Deserialize<DBUser>(stringObj));
            }

            return res;
        }
    }
}
