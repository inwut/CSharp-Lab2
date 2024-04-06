using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Lab2.Exceptions;
using Lab2.Models;
using Lab2.Service;
using Lab2.Tools;

namespace Lab2.ViewModels
{
    class PersonInfoViewModel : INotifyPropertyChanged
    {
        private RelayCommand<object> _proceedCommand;
        private RelayCommand<object> _cancelCommand;
        private RelayCommand<Person> _deleteCommand;
        private RelayCommand<Person> _updateCommand;
        private RelayCommand<object> _filterCommand;
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthDate = new DateTime(2000, 1, 1);
        private bool _isAdult;
        private bool _isBirthday;
        private string _sunSign;
        private string _chineseSign;
        private bool _isEnabled = true;
        private bool _isUpdate = false;
        private DateTime _defaultDate = new DateTime(2000, 1, 1);
        private string _filterName = "";
        private string _filterSurname = "";
        private string _filterEmail = ""; 
        private DateTime _filterBirthDateFrom = new DateTime(1980, 1, 1);
        private DateTime _filterBirthDateTo = new DateTime(2005, 1, 1);
        private string _filterIsAdult = "Both";
        private string _filterIsBirthday = "Both";
        private string _filterSunSign = "All";
        private string _filterChineseSign = "All";
        private string _updateEmail;
        public ObservableCollection<Person> _personsList;
        private UserService _userService;


        public PersonInfoViewModel()
        {
            _userService = new UserService();
            _personsList = new ObservableCollection<Person>(_userService.GetAllUsers());
        }

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
            get { return _surname; }
            set
            {
                _surname = value;
            }
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
            }
        }

        public string Email
        {
            get { return _email; }
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
            set
            {
                _isAdult = value;
            }
        }

        public bool IsBirthday
        {
            get
            {
                return _isBirthday;
            }
            set
            {
                _isBirthday = value;
            }
        }

        public string SunSign
        {
            get
            {
                return _sunSign;
            }
            set 
            { 
                _sunSign = value; 
            }
        }

        public string ChineseSign
        {
            get
            {
                return _chineseSign;
            }
            set 
            {
                _chineseSign = value;
            }
        }

        public string FilterName
        {
            get
            {
                return _filterName;
            }
            set 
            { 
                _filterName = value; 
            }
        }

        public string FilterSurame
        {
            get
            {
                return _filterSurname;
            }
            set
            {
                _filterSurname = value;
            }
        }

        public DateTime FilterBirthDateFrom
        {
            get
            { 
                return _filterBirthDateFrom; 
            }
            set
            {
                _filterBirthDateFrom = value;
            }
        }


        public DateTime FilterBirthDateTo
        {
            get
            {
                return _filterBirthDateTo;
            }
            set
            {
                _filterBirthDateTo = value;
            }
        }

        public string FilterEmail
        {
            get
            {
                return _filterEmail;
            }
            set
            {
                _filterEmail = value;
            }
        }

        public string FilterIsAdult
        {
            get
            {
                return _filterIsAdult;
            }
            set
            {
                _filterIsAdult = value;
            }
        }

        public string FilterIsBirthday
        {
            get
            {
                return _filterIsBirthday;
            }
            set
            {
                _filterIsBirthday = value;
            }
        }

        public string FilterSunSign
        {
            get
            {
                return _filterSunSign;
            }
            set
            {
                _filterSunSign = value;
            }
        }

        public string FilterChineseSign
        {
            get
            {
                return _filterChineseSign;
            }
            set
            {
                _filterChineseSign = value;
            }
        }

        public ObservableCollection<Person> PersonsList
        {
            get 
            { 
                return _personsList; 
            }
            set 
            { 
                _personsList = value; 
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

        public RelayCommand<object> CancelCommand
        {
            get
            {
                return _cancelCommand ??= new RelayCommand<object>(_ => Cancel(), _ => _isUpdate);
            }
        }

        public RelayCommand<Person> DeleteCommand
        {
            get
            {
                return _deleteCommand ??= new RelayCommand<Person>(person => Delete(person), _ => !_isUpdate);
            }
        }

        public RelayCommand<Person> UpdateCommand
        {
            get
            {
                return _updateCommand ??= new RelayCommand<Person>(person => Update(person), _ => !_isUpdate);
            }
        }

        public RelayCommand<object> FilterCommand
        {
            get
            {
                return _filterCommand ??= new RelayCommand<object>(_ => Filter(), _ => !_isUpdate);
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
                Person person = new Person(_name, _surname, _email, _birthDate);
                if (_isUpdate)
                {
                    await _userService.UpdatePerson(person, _updateEmail);
                } else
                {
                    await _userService.AddPerson(person);
                }
            }
            catch (PersonValidationException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                _personsList = new ObservableCollection<Person>(_userService.GetAllUsers());
                IsEnabled = true;
                _updateEmail = "";
                _isUpdate = false;
                _name = "";
                _email = "";
                _birthDate = _defaultDate;
                _surname = "";
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Surname));
                OnPropertyChanged(nameof(Email));
                OnPropertyChanged(nameof(BirthDate));
                Filter();
            }
        }

        private void Cancel()
        {
            _updateEmail = "";
            _isUpdate = false;
            _name = "";
            _email = "";
            _birthDate = _defaultDate;
            _surname = "";
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Surname));
            OnPropertyChanged(nameof(Email));
            OnPropertyChanged(nameof(BirthDate));
        }

        private void Delete(Person person)
        {
            try
            {
                _userService.DeletePerson(person.Email);
                _personsList.Remove(person);
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                Filter();
                IsEnabled = true;
            }
        }

        private void Update(Person person)
        {
            _isUpdate = true;
            _updateEmail = person.Email;
            _name = person.Name;
            _email = person.Email;
            _birthDate = person.BirthDate;  
            _surname = person.Surname;
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Surname));
            OnPropertyChanged(nameof(Email));
            OnPropertyChanged(nameof(BirthDate));
        }

        private void Filter()
        {
            var filtered = _userService.GetAllUsers()
                .Where(user => user.Name.ToLower().Contains(FilterName.ToLower()))
                .Where(user => user.Surname.ToLower().Contains(FilterSurame.ToLower()))
                .Where(user => user.Email.ToLower().Contains(FilterEmail.ToLower()))
                .Where(user => user.BirthDate >= FilterBirthDateFrom)
                .Where(user => user.BirthDate <= FilterBirthDateTo);
            if (FilterIsBirthday.Equals("Is Birthday"))
            {
                filtered = filtered.Where(user => user.IsBirthday);
            }
            if (FilterIsBirthday.Equals("Isn't Birthday"))
            {
                filtered = filtered.Where(user => !user.IsBirthday);
            }
            if (FilterIsAdult.Equals("Is Adult"))
            {
                filtered = filtered.Where(user => user.IsAdult);
            }
            if (FilterIsAdult.Equals("Isn't Adult"))
            {
                filtered = filtered.Where(user => !user.IsAdult);
            }
            if (!FilterSunSign.Equals("All"))
            {
                filtered = filtered.Where(user => user.SunSign == FilterSunSign);
            }
            if (!FilterChineseSign.Equals("All"))
            {
                filtered = filtered.Where(user => user.ChineseSign == FilterChineseSign);
            }
            PersonsList = new ObservableCollection<Person>(filtered);
            OnPropertyChanged(nameof(PersonsList));
        }
    }
}
