using System;
using System.Collections.ObjectModel;
using XamarinExample.Models;

namespace XamarinExample.ViewModels
{
    public class ContactBookMVVMViewModel : BaseViewModel
    {
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

        public ContactBookMVVMViewModel(ContactBookMVVM contactBook)
        {
            Id = contactBook.Id;
            _firstName = contactBook.FirstName;
            _lastName = contactBook.LastName;
            PhoneNumber = contactBook.PhoneNumber;
            EmailAddress = contactBook.EmailAddress;
            IsBlocked = contactBook.IsBlocked;
        }

        public ContactBookMVVMViewModel() {
        }
    }
}