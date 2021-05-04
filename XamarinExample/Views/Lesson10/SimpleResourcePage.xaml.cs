using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinExample.Views.Lesson10
{
    public partial class SimpleResourcePage : ContentPage
    {
        public SimpleResourcePage()
        {
            InitializeComponent();
        }

        void Button_Clicked(object sender, EventArgs e)
        {
            Resources["buttonBackgroundColor"] = Color.Pink;
        }
    }
}
