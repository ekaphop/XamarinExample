using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace XamarinExample.Views.Section2
{
    [XamlCompilation(XamlCompilationOptions.Skip)]
    public partial class EssentialExercisePage : ContentPage
    {
        private int _index = 0;
        private string[] _quotes = new string[]
        {
            "Life is like riding a bicycle. To keep your balance, you must keep moving.",
            "You can't blame gravity for falling in love.",
            "Look deep into nature, and then you will understand everything better."
        };

        public EssentialExercisePage()
        {
            InitializeComponent();

            currentQuote.Text = _quotes[_index];

            if (Device.RuntimePlatform == Device.iOS)
            {
                stackLayout.Padding = new Thickness(20, 30, 20, 20);
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                stackLayout.Padding = new Thickness(20, 30, 20, 20);
            }
            else if (Device.RuntimePlatform == Device.UWP)
            {
                stackLayout.Padding = new Thickness(20, 40, 20, 20);
            }
                
        }

        void Button_Clicked(object sender, System.EventArgs e)
        {
            _index++;
            if (_index >= _quotes.Length)
                _index = 0;

            currentQuote.Text = _quotes[_index];
        }
    }
}