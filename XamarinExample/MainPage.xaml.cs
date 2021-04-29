using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinExample.Views.Section2;

namespace XamarinExample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void Section2Label_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EssentialExercisePage());
        }

    }
}
