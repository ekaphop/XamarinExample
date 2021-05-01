using Xamarin.Forms;

namespace XamarinExample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void ExerciseButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ExercisePage());
        }

        async void LessonButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new LessonPage());
        }
    }
}