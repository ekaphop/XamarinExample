using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinExample.Views.Lesson5
{
    public partial class BasicListPage : ContentPage
    {
        public BasicListPage()
        {
            InitializeComponent();

            var names = new List<string> {
                "Service 1","Service 2","Service 3"
            };

            basicListView.ItemsSource = names;
        }
    }
}
