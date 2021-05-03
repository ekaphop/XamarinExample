using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SQLite;
using Xamarin.Forms;
using XamarinExample.Models;
using XamarinExample.Persistence;

namespace XamarinExample.Views.Section8
{
    public partial class ContactBookSQLitePage : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<ContactBookSQLite> _contactBooks;
        public ObservableCollection<ContactBookSQLite> ContactBooks
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

        public ContactBookSQLitePage()
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<ContactBookSQLite>();

            var contactBooks = await _connection.Table<ContactBookSQLite>().ToListAsync();
            _contactBooks = new ObservableCollection<ContactBookSQLite>(contactBooks);
            listView.ItemsSource = _contactBooks;

            base.OnAppearing();
        }


        async void ListView_Refreshing(object sender, EventArgs e)
        {
            var contactBooks = await _connection.Table<ContactBookSQLite>().ToListAsync();
            _contactBooks = new ObservableCollection<ContactBookSQLite>(contactBooks);
            listView.ItemsSource = _contactBooks;
            listView.EndRefresh();
        }

        async void DeleteMenuItem_Clicked(object sender, EventArgs e)
        {
            var contackBook = (sender as MenuItem).CommandParameter as ContactBookSQLite;
            var deleteMessage = "Are you sure you want to delete " + contackBook.Fullname;
            var response = await DisplayAlert("Warning", deleteMessage, "Yes", "No");

            if (response) //User click Yes
            {
                ContactBooks.Remove(contackBook);
                await _connection.DeleteAsync(contackBook);
            }  
        }

        async void ToolbarItem_AddContact_Clicked(object sender, EventArgs e)
        {
            var page = new ContactBookSQLiteDetailsPage("add");

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

            var contactBookPassingData = e.SelectedItem as ContactBookSQLite;

            var page = new ContactBookSQLiteDetailsPage("edit", contactBookPassingData);

            page.ContactBookEvent += (source, contact) =>
            {
                var selectContactBook = _contactBooks.Where(s => s.Id == contactBookPassingData.Id);

                foreach (ContactBookSQLite book in selectContactBook)
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
