using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinExample.Views.Lesson7
{
    public partial class TableViewPage : ContentPage
    {
        public TableViewPage()
        {
            InitializeComponent();
        }

        void ViewCell_Tapped(object sender, EventArgs e)
        {
            var page = new ContactMethodPage();

            page.ContactMethod.ItemSelected += (source, args) =>
            {
                contactMethod.Text = args.SelectedItem.ToString();
                Navigation.PopAsync();
            };

            Navigation.PushAsync(page);
        }
    }
}
