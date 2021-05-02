using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinExample.Views.Lesson6
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {    
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new IntroductionPage());
        }
    }
}
