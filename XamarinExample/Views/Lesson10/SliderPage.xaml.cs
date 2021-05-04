using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinExample.Views.Lesson10
{
    public partial class SliderPage : ContentPage
    {
        public SliderPage()
        {
            InitializeComponent();
        }

        void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            MessagingCenter.Send(this, "SliderValueChanged", e.NewValue);
        }
    }
}
