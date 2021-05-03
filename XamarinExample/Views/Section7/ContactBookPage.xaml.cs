using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using XamarinExample.Models;

namespace XamarinExample.Views.Section7
{
    public partial class ContactBookPage : ContentPage
    {
        /**
        * I'm search 'xamarin forms pass data to previous page' on Google
        * and everybody suggest C# event and MessagingCenter but MessagingCenter is on Section10 
        * and i search C# event again and can find C# EventHandler
        */

        private ObservableCollection<ContactBook> _contactBooks;
        public ObservableCollection<ContactBook> ContactBooks
        {
            get
            {
                return _contactBooks;
            }
            set
            {
                if (_contactBooks != value)
                {
                    _contactBooks = value;
                    OnPropertyChanged(nameof(ContactBooks));
                }
            }
        }

        public ContactBookPage()
        {
            InitializeComponent();

            ContactBooks = new ObservableCollection<ContactBook>
            {
                new ContactBook { Id=1, FirstName="Ekaphop", LastName="Khainara" ,CanSave=true }
                ,new ContactBook { Id=2, FirstName="Mosh", LastName="Hamedani" ,CanSave=true}
                ,new ContactBook { Id=3, FirstName="John", LastName="Smith" ,CanSave=true }
            };

            listView.ItemsSource = ContactBooks;
        }

        void ListView_Refreshing(object sender, EventArgs e)
        {
            listView.ItemsSource = ContactBooks;
            listView.EndRefresh();
        }

        async void DeleteMenuItem_Clicked(object sender, EventArgs e)
        {
            var contackBook = (sender as MenuItem).CommandParameter as ContactBook;
            var deleteMessage = "Are you sure you want to delete " + contackBook.Fullname;
            var response = await DisplayAlert("Warning", deleteMessage, "Yes", "No");

            if (response) //User click Yes
                ContactBooks.Remove(contackBook);
        }

        async void ToolbarItem_AddContact_Clicked(object sender, EventArgs e)
        {
            var page = new ContactBookDetailsPage("add");

            page.ContactBookEvent += (source, contact) =>
            {
                _contactBooks.Add(contact);
            };

            await Navigation.PushAsync(page);
        }

        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var contactBookPassingData = e.SelectedItem as ContactBook;

            var page = new ContactBookDetailsPage("edit",contactBookPassingData);

            page.ContactBookEvent += (source, contact) =>
            {
                var selectContactBook = _contactBooks.Where(s => s.Id == contactBookPassingData.Id);

                foreach (ContactBook book in selectContactBook)
                {
                    book.FirstName = contact.FirstName;
                    book.LastName = contact.LastName;
                    book.PhoneNumber = contact.PhoneNumber;
                    book.EmailAddress = contact.EmailAddress;
                    book.IsBlocked = contact.IsBlocked;
                    book.CanSave = contact.CanSave;
                }
            };

            await Navigation.PushAsync(page);

            listView.SelectedItem = null;
        }     
    }
}
