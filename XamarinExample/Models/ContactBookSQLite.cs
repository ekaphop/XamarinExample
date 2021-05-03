using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;

namespace XamarinExample.Models
{
    public class ContactBookSQLite : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName == value)
                    return;

                _firstName = value;

                OnPropertyChanged(nameof(FirstName));
                OnPropertyChanged(nameof(Fullname));
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName == value)
                    return;

                _lastName = value;

                OnPropertyChanged(nameof(LastName));
                OnPropertyChanged(nameof(Fullname));
            }
        }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public bool IsBlocked { get; set; }
        public bool CanSave { get; set; }

        public string Fullname => $"{FirstName} {LastName}";

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
