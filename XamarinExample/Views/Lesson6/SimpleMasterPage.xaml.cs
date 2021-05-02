using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinExample.Models;

namespace XamarinExample.Views.Lesson6
{
    public partial class SimpleMasterPage : ContentPage
    {
        public SimpleMasterPage()
        {
            InitializeComponent();

            //Mock data
            var contacts = new List<Contact> {
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

            //Binding
            textCellListView.ItemsSource = contacts;
        }

        async void textCellListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var contact = e.SelectedItem as Contact;
            await Navigation.PushAsync(new SimpleDetailPage(contact));
            textCellListView.SelectedItem = null;
        }
    }
}