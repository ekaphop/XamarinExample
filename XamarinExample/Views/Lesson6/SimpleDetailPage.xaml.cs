using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinExample.Models;

namespace XamarinExample.Views.Lesson6
{
    public partial class SimpleDetailPage : ContentPage
    {
        public SimpleDetailPage(Contact contact)
        {
            BindingContext = contact ?? throw new ArgumentNullException();

            InitializeComponent();
        }
    }
}
