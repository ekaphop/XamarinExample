using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinExample
{
    public partial class App : Application
    {
        private const string TitleKey = "Name";
        private const string NotificationsKey = "NotificationsEnabled";

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public string AppTitleKey
        {
            get
            {
                if (Properties.ContainsKey(TitleKey))
                    return Properties[TitleKey].ToString();

                return "";
            }
            set
            {
                Properties[TitleKey] = value;
            }
        }

        public bool AppNotificationsEnabled
        {
            get
            {
                if (Properties.ContainsKey(NotificationsKey))
                    return (bool)Properties[NotificationsKey];

                return false;
            }
            set
            {
                Properties[NotificationsKey] = value;
            }
        }
    }
}
