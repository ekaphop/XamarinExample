using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;
using XamarinExample.Models;
using XamarinExample.Persistence;

namespace XamarinExample.Views.Section8
{
    public partial class ContactBookSQLiteDetailsPage : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        private string _commandType = "";
        private int _Id = 0;

        public event EventHandler<ContactBookSQLite> ContactBookEvent;

        private ContactBookSQLite _contactBookData;
        public ContactBookSQLite ContactBookData
        {
            get { return _contactBookData; }
            set
            {
                _contactBookData = value;
                OnPropertyChanged(nameof(ContactBookData));
            }
        }

        public ContactBookSQLiteDetailsPage(string commandType, ContactBookSQLite contact = null)
        {
            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            if (commandType == "add")
            {
                _commandType = commandType;
            }
            else if (commandType == "edit")
            {
                _commandType = commandType;
                _Id = contact.Id;
                BindingContext = contact ?? throw new ArgumentNullException();
            }
        }

        async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var contact = new ContactBookSQLite();

            if (_commandType == "edit")
                contact.Id = _Id;

            if (string.IsNullOrWhiteSpace(firstnameEntryCell.Text)
                    || string.IsNullOrWhiteSpace(lastnameEntryCell.Text))
            {
                await DisplayAlert("Error", "Please enter the name.", "OK");
                return;
            }

            contact.FirstName = firstnameEntryCell.Text;
            contact.LastName = lastnameEntryCell.Text;

            if (!string.IsNullOrWhiteSpace(phoneEntryCell.Text))
                contact.PhoneNumber = phoneEntryCell.Text;

            if (!string.IsNullOrWhiteSpace(emailEntryCell.Text))
                contact.EmailAddress = emailEntryCell.Text;

            contact.IsBlocked = blockedSwitchCell.On;

            if(_commandType == "add")
                await _connection.InsertAsync(contact);
            else if(_commandType == "edit")
                await _connection.UpdateAsync(contact);

            // Return Event value
            ContactBookEvent?.Invoke(this, contact);

            await Navigation.PopAsync();
        }
    }
}
