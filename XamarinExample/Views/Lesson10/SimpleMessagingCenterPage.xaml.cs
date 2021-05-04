using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinExample.Views.Lesson10
{
    public partial class SimpleMessagingCenterPage : ContentPage
    {
        public SimpleMessagingCenterPage()
        {
            InitializeComponent();
        }

        void Button_Clicked(object sender, EventArgs e)
        {
            var page = new SliderPage();

            MessagingCenter.Subscribe<SliderPage, double>(this, "SliderValueChanged", OnSliderValueChanged);

            Navigation.PushAsync(page);

            MessagingCenter.Unsubscribe<SimpleMessagingCenterPage>(this, "SliderValueChanged");
        }

        private void OnSliderValueChanged(SliderPage source, double newValue)
        {
            sliderValueLabel.Text = newValue.ToString();
        }
    }
}
