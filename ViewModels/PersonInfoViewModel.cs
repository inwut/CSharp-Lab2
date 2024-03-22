using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Lab2.Exceptions;
using Lab2.Models;
using Lab2.Tools;

namespace Lab2.ViewModels
{
    class PersonInfoViewModel : INotifyPropertyChanged
    {
        private Person? _person;
        private RelayCommand<object> _proceedCommand;
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthDate;
        private bool _isEnabled = true;

        public string Name
        {
            get
            {
                return _person.Name;
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
                return _person.Surname;
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
                return _person.BirthDate;
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
                return _person.Email;
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
                return _person.IsAdult;
            }
        }

        public bool IsBirthday
        {
            get
            {
                return _person.IsBirthday;
            }
        }

        public string SunSign
        {
            get
            {
                return _person.SunSign;
            }
        }

        public string ChineseSign
        {
            get
            {
                return _person.ChineseSign;
            }
        }

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                OnPropertyChanged(nameof(IsEnabled));
            }
        }

        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand ??= new RelayCommand<object>(_ => Proceed(), CanProceed);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private bool CanProceed(object parameter)
        {
            return !(string.IsNullOrWhiteSpace(_name) || string.IsNullOrWhiteSpace(_surname)
                || string.IsNullOrWhiteSpace(_email) || _birthDate.Equals(DateTime.MinValue));
        }

        private async void Proceed()
        {
            try
            {
                IsEnabled = false;
                _person = await Task.Run(() => new Person(_name, _surname, _email, _birthDate));
            }
            catch (PersonValidationException ex)
            {

                _person = null;
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                IsEnabled = true;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Surname));
                OnPropertyChanged(nameof(Email));
                OnPropertyChanged(nameof(BirthDate));
                OnPropertyChanged(nameof(IsAdult));
                OnPropertyChanged(nameof(IsBirthday));
                OnPropertyChanged(nameof(SunSign));
                OnPropertyChanged(nameof(ChineseSign));
            }
            if (_person.IsBirthday)
            {
                MessageBox.Show("Happy Birthday!");
            }
        }

    }
}
