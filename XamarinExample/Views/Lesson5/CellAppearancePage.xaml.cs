using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinExample.Models;

namespace XamarinExample.Views.Lesson5
{
    public partial class CellAppearancePage : ContentPage
    {
        public CellAppearancePage()
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
            imageCellListView.ItemsSource = contacts;
            viewCellListView.ItemsSource = contacts;
        }
    }
}
