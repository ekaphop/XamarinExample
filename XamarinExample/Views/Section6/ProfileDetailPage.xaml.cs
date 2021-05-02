using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinExample.Models;

namespace XamarinExample.Views.Section6
{
    public partial class ProfileDetailPage : ContentPage
    {
        public ProfileDetailPage(UserProfile profile)
        {
            BindingContext = profile ?? throw new ArgumentNullException();
            InitializeComponent();
        }
    }
}
