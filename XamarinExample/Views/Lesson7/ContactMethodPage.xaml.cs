using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinExample.Views.Lesson7
{
    public partial class ContactMethodPage : ContentPage
    {
        private List<string> _contact;

        public ListView ContactMethod
        {
            get { return listView; }
        }
        
        public ContactMethodPage()
        {
            InitializeComponent();

            _contact = new List<string> { "None","Email","SMS" };

            listView.ItemsSource = _contact;
        }
    }
}
