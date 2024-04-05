using Lab2.Exceptions;
using Lab2.Models;
using Lab2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Service
{
    internal class UserService
    {
        private FileRepository Repository = new FileRepository();

        public List<Person> GetAllUsers()
        {
            var res = new List<Person>();
            foreach (var person in Repository.GetAll())
            {
                res.Add(new Person(person.Name, person.Surname, person.Email, person.BirthDate));
            }
            return res;
        }

        public async Task<bool> AddPerson(Person person)
        {
            DBUser dBUser = await Repository.GetAsync(person.Email);
            if (dBUser != null) 
            {
                throw new PersonValidationException("User already exist");
            }
            var dbUser = new DBUser(person.Name, person.Surname, person.Email, person.BirthDate);
            await Repository.AddAsync(dbUser);
            return true;
        }

        public async Task<bool> UpdatePerson(Person person, string email)
        {
            DeletePerson(email);
            var dbUser = new DBUser(person.Name, person.Surname, person.Email, person.BirthDate);
            await Repository.AddAsync(dbUser);
            return true;
        }

        public bool DeletePerson(string email)
        {
            Repository.Delete(email);
            return true;
        }
    }
}
