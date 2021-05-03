using System;
using Xamarin.Forms;
using XamarinExample.Views.Section2;
using XamarinExample.Views.Section3;
using XamarinExample.Views.Section4;
using XamarinExample.Views.Section5;
using XamarinExample.Views.Section6;
using XamarinExample.Views.Section7;
using XamarinExample.Views.Section8;

namespace XamarinExample
{
    public partial class ExercisePage : ContentPage
    {
        public ExercisePage()
        {
            InitializeComponent();
        }

        #region ----- Section 2 -----
        async void Section2_Label_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EssentialExercisePage());
        }
        #endregion

        #region ----- Section 3 -----
        async void Section3_StackLayout_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StackLayoutExercisePage());
        }

        async void Section3_StackLayout2_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StackLayoutExercise2Page());
        }

        async void Section3_Grid_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GridExercisePage());
        }

        async void Section3_Grid2_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GridExercise2Page());
        }

        async void Section3_AbsoluteLayout_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AbsoluteLayoutExercisePage());
        }

        async void Section3_AbsoluteLayout2_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AbsoluteLayoutExercise2Page());
        }

        async void Section3_RelativeLayout_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RelativeLayoutExercisePage());
        }
        #endregion

        #region ----- Section 4 -----
        async void Section4_ImageExercise_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImageExercisePage());
        }
        #endregion

        #region ----- Section 5 -----
        async void Section5_Airbnb_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HotelBookingPage());
        }
        #endregion

        #region ----- Section 6 -----
        async void Section6_Instagram_Tapped(object sender, EventArgs e)
            => await Navigation.PushAsync(new InstagramAppPage());

        #endregion

        #region ----- Section 7 -----
        async void Section7_ContactBook_Tapped(object sender, EventArgs e)
            => await Navigation.PushAsync(new ContactBookPage());
        #endregion

        #region ----- Section 8 -----
        async void Section8_ContactBook_Tapped(object sender, EventArgs e)
            => await Navigation.PushAsync(new ContactBookSQLitePage());
        #endregion
    }
}
