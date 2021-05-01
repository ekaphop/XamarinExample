using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using XamarinExample.Models;

namespace XamarinExample.Views.Lesson5
{
    public partial class ListViewSearchBarPage : ContentPage
    {
        IEnumerable<Contact> GetContacts(string searchText = null)
        {
            var contacts = new List<Contact> {
                new Contact {
                    Name = "Acer",
                    ImageUrl = "https://image.freepik.com/free-icon/running-man_318-1564.jpg"
                },
                new Contact {
                    Name = "Mac",
                    Status = "Let's talk to team.",
                    ImageUrl = "https://image.freepik.com/free-icon/person-street-view-symbol_318-1051.jpg"
                },
                new Contact {
                    Name = "Dell",
                    Status  = "Nice to meet you.",
                    ImageUrl = "https://image.freepik.com/free-icon/group-meeting_318-10037.jpg"
                }
            };

            if (String.IsNullOrWhiteSpace(searchText))
                return contacts;

            return contacts.Where(s => s.Name.StartsWith(searchText));
        }

        public ListViewSearchBarPage()
        {
            InitializeComponent();

            textCellListView.ItemsSource = GetContacts();
        }

        void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            textCellListView.ItemsSource = GetContacts(e.NewTextValue);
        }

    }
}
