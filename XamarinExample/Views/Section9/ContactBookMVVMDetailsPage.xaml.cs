using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinExample.ViewModels;

namespace XamarinExample.Views.Section9
{
    public partial class ContactBookMVVMDetailsPage : ContentPage
    {
        public ContactBookMVVMDetailsPage(ContactBookMVVMDetailsViewModel vm)
        {
            BindingContext = vm;
            InitializeComponent();
        }
    }
}
