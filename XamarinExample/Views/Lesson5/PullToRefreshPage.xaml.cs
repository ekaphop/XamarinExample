using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinExample.Models;

namespace XamarinExample.Views.Lesson5
{
    public partial class PullToRefreshPage : ContentPage
    {
        List<Contact> GetContacts()
        {
            return new List<Contact> {
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
        }

        public PullToRefreshPage()
        {
            InitializeComponent();
            viewCellListView.ItemsSource = GetContacts();
        }

        void ListView_Refreshing(System.Object sender, System.EventArgs e)
        {
            viewCellListView.ItemsSource = GetContacts();
            Task.Delay(2000);
            viewCellListView.EndRefresh();
        }
    }
}
