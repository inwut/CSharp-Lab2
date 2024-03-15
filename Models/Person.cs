using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab2.Models
{
    class Person
    {

		private string _name;
        private string _surname;
		private string _email;
		private DateTime _birthDate;
        private readonly bool _isAdult;
        private readonly bool _isBirthday;
        private readonly string _sunSign;
        private readonly string _chineseSign;


        public string Name
		{
			get 
            {
                return _name; 
            }
			set 
            { 
                _name = value; 
            }
		}

		public string Surname
		{
			get 
            { 
                return _surname; 
            }
			set 
            {
                _surname = value; 
            }
		}

        public DateTime BirthDate
        {
            get 
            { 
                return _birthDate; 
            }
            set 
            { 
                _birthDate = value; 
            }
        }

        public string Email
        {
            get 
            { 
                return _email; 
            }
            set 
            { 
                _email = value; 
            }
        }

        public bool IsAdult 
        {
            get
            {
                return _isAdult;
            }
        }

        public bool IsBirthday
        {
            get
            {
                return _isBirthday;
            }
        }

        public string SunSign
        {
            get
            {
                return _sunSign;
            }
        }

        public string ChineseSign
        {
            get
            {
                return _chineseSign;
            }
        }

        public Person(string name, string surname, string email, DateTime birthDate)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _birthDate = birthDate;
            _isAdult = CheckAdult();
            _isBirthday = CheckBirthday();
            _sunSign = GetSunZodiacSign();
            _chineseSign = GetChineseZodiacSign();
            int age = CalculateAge();
            if (age < 0 || age > 135)
            {
                throw new ArgumentException("Wrong Age");
            }
            Thread.Sleep(3000);
        }

        public Person(string name, string surname, string email) : this(name, surname, email, DateTime.MinValue)
        {
            
        }

        public Person(string name, string surname, DateTime birthDate) : this(name, surname, string.Empty, birthDate)
        {
            
        }

        private int CalculateAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - BirthDate.Year;
            if (BirthDate.Date > today.AddYears(-age))
                age--;
            return age;
        }

        private bool CheckAdult() 
        {
            
            return CalculateAge() >= 18;
        }

        private bool CheckBirthday()
        {
            return BirthDate.Month == DateTime.Today.Month && BirthDate.Day == DateTime.Today.Day;
        }

        private string GetSunZodiacSign()
        {
            int month = BirthDate.Month;
            int day = BirthDate.Day;

            switch (month)
            {
                case 1:
                    return (day <= 20) ? "Capricorn" : "Aquarius";
                case 2:
                    return (day <= 19) ? "Aquarius" : "Pisces";
                case 3:
                    return (day <= 20) ? "Pisces" : "Aries";
                case 4:
                    return (day <= 20) ? "Aries" : "Taurus";
                case 5:
                    return (day <= 21) ? "Taurus" : "Gemini";
                case 6:
                    return (day <= 21) ? "Gemini" : "Cancer";
                case 7:
                    return (day <= 22) ? "Cancer" : "Leo";
                case 8:
                    return (day <= 23) ? "Leo" : "Virgo";
                case 9:
                    return (day <= 23) ? "Virgo" : "Libra";
                case 10:
                    return (day <= 23) ? "Libra" : "Scorpio";
                case 11:
                    return (day <= 22) ? "Scorpio" : "Sagittarius";
                case 12:
                    return (day <= 21) ? "Sagittarius" : "Capricorn";
                default:
                    return "None";
            }
        }

        private string GetChineseZodiacSign()
        {
            int year = BirthDate.Year;
            int chineseSign = year % 12;
            return ((ChineseZodiac)chineseSign).ToString();
        }

    }

    enum ChineseZodiac
    {
        Monkey,
        Rooster,
        Dog,
        Pig,
        Rat,
        Ox,
        Tiger,
        Rabbit,
        Dragon,
        Snake,
        Horse,
        Sheep
    }
}
