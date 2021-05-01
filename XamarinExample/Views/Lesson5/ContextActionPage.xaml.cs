using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using XamarinExample.Models;

namespace XamarinExample.Views.Lesson5
{
    public partial class ContextActionPage : ContentPage
    {
        private ObservableCollection<Contact> _contacts;
        public ObservableCollection<Contact> Contacts
        {
            get
            {
                return _contacts;
            }
            set
            {
                if (_contacts != value)
                {
                    _contacts = value;
                    OnPropertyChanged(nameof(Contact));
                }
            }
        }

        public ContextActionPage()
        {
            InitializeComponent();

            Contacts = new ObservableCollection<Contact> {
                new Contact {
                    Name = "Person 1",
                    ImageUrl = "https://image.freepik.com/free-icon/running-man_318-1564.jpg"
                },
                new Contact {
                    Name = "Person 2",
                    Status = "Let's talk to team.",
                    ImageUrl = "https://image.freepik.com/free-icon/person-street-view-symbol_318-1051.jpg"
                },
                new Contact {
                    Name = "Person 3",
                    Status  = "Nice to meet you.",
                    ImageUrl = "https://image.freepik.com/free-icon/group-meeting_318-10037.jpg"
                }
            };

            textCellListView.ItemsSource = Contacts;
        }

        void CallMenuItem_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var contact = menuItem.CommandParameter as Contact;
            DisplayAlert("Tapped", contact.Name, "OK");
        }

        void DeleteMenuItem_Clicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            Contacts.Remove(contact);
        }
    }
}
