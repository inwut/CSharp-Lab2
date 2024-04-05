using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Models
{
    internal class DBUser
    {
        public DBUser(string name, string surname, string email, DateTime birthDate)
        {
            Name = name;
            Surname = surname;
            Email = email;
            BirthDate = birthDate;
        }

        public string Name { get; }

        public string Surname { get; }

        public DateTime BirthDate { get; }

        public string Email { get; }
    }
}
