using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinExample.Models;

namespace XamarinExample.Views.Section7
{
    public partial class ContactBookDetailsPage : ContentPage
    {
        private string _commandType = "";
        private int _Id = 0;

        public event EventHandler<ContactBook> ContactBookEvent;

        private ContactBook _contactBookData;
        public ContactBook ContactBookData
        {
            get { return _contactBookData; }
            set
            {
                _contactBookData = value;
                OnPropertyChanged(nameof(ContactBookData));
            }
        }

        public ContactBookDetailsPage(string commandType,ContactBook contact = null)
        {
            InitializeComponent();

            if(commandType == "add")
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
            var contact = new ContactBook();

            if(_commandType == "edit")
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

            // Return Event value
            ContactBookEvent?.Invoke(this, contact);

            await Navigation.PopAsync();
        }
    }
}