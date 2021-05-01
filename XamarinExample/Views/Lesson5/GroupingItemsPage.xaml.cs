using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinExample.Models;

namespace XamarinExample.Views.Lesson5
{
    public partial class GroupingItemsPage : ContentPage
    {
        public GroupingItemsPage()
        {
            InitializeComponent();

            var groupingItems = new List<ContactGroup> {

                new ContactGroup("E", "E")
                {
                    new Contact{
                        Name="Ekaphop",
                        Status="Learning every day.",
                        ImageUrl="https://image.freepik.com/free-icon/running-man_318-1564.jpg" }
                },

                new ContactGroup("J", "J")
                {
                    new Contact {
                        Name = "Jojo",
                        Status = "Let's talk to team.",
                        ImageUrl = "https://image.freepik.com/free-icon/person-street-view-symbol_318-1051.jpg"
                    },
                    new Contact {
                        Name = "Jonathan",
                        Status  = "Nice to meet you.",
                        ImageUrl = "https://image.freepik.com/free-icon/group-meeting_318-10037.jpg"
                    }
                },

            };

            groupingListView.ItemsSource = groupingItems;
        }

        void GroupingListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //var contact = e.SelectedItem as Contact;
            groupingListView.SelectedItem = null;
        }

        void GroupingListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var contact = e.Item as Contact;
            DisplayAlert("Tapped",contact.Name,"OK");
        }
    }
}
