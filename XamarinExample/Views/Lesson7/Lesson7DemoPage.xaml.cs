using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinExample.Models;

namespace XamarinExample.Views.Lesson7
{
    public partial class Lesson7DemoPage : ContentPage
    {
        private IList<ContactMethod> _contactMethods;
        public Lesson7DemoPage()
        {
            InitializeComponent();
            label.IsVisible = false;

            GetContactMethods();
            foreach (var method in _contactMethods)
            {
                pickerUi.Items.Add(method.Name);
            }
        }

        private void GetContactMethods()
        {
            _contactMethods = new List<ContactMethod> {
                new ContactMethod { Id=1,Name="SMS" },
                new ContactMethod { Id=2,Name="Email" }
            };
        }

        void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            label.IsVisible = e.Value;
        }

        void SliderUi_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            
        }

        void PasswordEntry_Completed(object sender, EventArgs e)
        {
            passwordCompletedLabel.Text = "Completed";
        }


        void PasswordEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            passwordTextChangedLabel.Text = e.NewTextValue;
            passwordCompletedLabel.Text = "";
        }

        void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var contactMethod = contactMethods.Items[contactMethods.SelectedIndex];
            DisplayAlert("Selection",contactMethod,"OK");
        }

        void PickerUi_SelectedIndexChanged(object sender, EventArgs e)
        {
            var contactMethod = pickerUi.Items[pickerUi.SelectedIndex];
            DisplayAlert("Selection", contactMethod, "OK");
        }

        void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            var datetimePicker = e.NewDate;
        }
    }
}
