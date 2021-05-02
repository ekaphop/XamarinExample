using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using XamarinExample.Models;

namespace XamarinExample.Views.Section6
{
    public partial class ActivityPage : ContentPage
    {
        private List<UserProfile> _users = new List<UserProfile>
        {
            new UserProfile { Id = 1,
                Name = "Jenny Dalby",
                Description = "My name is Jenny Dalby",
                ImageUrl = "https://image.freepik.com/free-icon/running-man_318-1564.jpg"
                },
            new UserProfile { Id = 2,
                Name = "Jon v",
                Description = "My name is Jon V",
                ImageUrl = "https://image.freepik.com/free-icon/person-street-view-symbol_318-1051.jpg"
                },
            new UserProfile { Id = 3,
                Name = "Rachel Martin",
                Description = "My name is Rachel Martin",
                ImageUrl = "https://image.freepik.com/free-icon/group-meeting_318-10037.jpg"
                },
            new UserProfile { Id = 4,
                Name = "Nivan Jay",
                Description = "My name is Nivan Jay",
                ImageUrl = "https://image.freepik.com/free-icon/running-man_318-1564.jpg"
                },
            new UserProfile { Id = 5,
                Name = "Sanaz Z",
                Description = "My name is SanazZ",
                ImageUrl = "https://image.freepik.com/free-icon/person-street-view-symbol_318-1051.jpg"
                },
            new UserProfile { Id = 6,
                Name = "Next Lab",
                Description = "My name is Next Lab",
                ImageUrl = "https://image.freepik.com/free-icon/group-meeting_318-10037.jpg"
                },
            new UserProfile { Id = 7,
                Name = "Alex B",
                Description = "My name is Alex B",
                ImageUrl = "https://image.freepik.com/free-icon/running-man_318-1564.jpg"
                },
            new UserProfile { Id = 8,
                Name = "Tara Chang",
                Description = "My name is Tara Chang",
                ImageUrl = "https://image.freepik.com/free-icon/person-street-view-symbol_318-1051.jpg"
                },
            new UserProfile { Id = 9,
                Name = "Tom K",
                Description = "My name is Tom K",
                ImageUrl = "https://image.freepik.com/free-icon/group-meeting_318-10037.jpg"
                }
        };

        public ActivityPage()
        {
            InitializeComponent();

            //Mock data
            var contacts = new List<Activity> {
                new Activity {
                    UserId = 1,
                    Description = "Your Facebook friend Jenny Dalby is on Instagram.",
                    ImageUrl = "https://image.freepik.com/free-icon/running-man_318-1564.jpg"
                },
                new Activity {
                    UserId = 2,
                    Description = "Jonv started following you",
                    ImageUrl = "https://image.freepik.com/free-icon/person-street-view-symbol_318-1051.jpg"
                },
                new Activity {
                    UserId = 3,
                    Description = "RachelMartin liked your photo.",
                    ImageUrl = "https://image.freepik.com/free-icon/group-meeting_318-10037.jpg"
                },
                 new Activity {
                    UserId = 4,
                     Description = "Your Facebook friend Nivan Jay is on Instagram.",
                    ImageUrl = "https://image.freepik.com/free-icon/running-man_318-1564.jpg"
                },
                new Activity {
                    UserId = 5,
                    Description = "SanazZ sent a photo posted by @brookeisep.",
                    ImageUrl = "https://image.freepik.com/free-icon/person-street-view-symbol_318-1051.jpg"
                },
                new Activity {
                    UserId = 6,
                    Description = "NextLab started following you.",
                    ImageUrl = "https://image.freepik.com/free-icon/group-meeting_318-10037.jpg"
                },
                 new Activity {
                    UserId = 7,
                    Description = "Your Facebook friend Alex B is on Instagram.",
                    ImageUrl = "https://image.freepik.com/free-icon/running-man_318-1564.jpg"
                },
                new Activity {
                    UserId = 8,
                    Description = "Your Facebook friend Tara Chang is on Instagram.",
                    ImageUrl = "https://image.freepik.com/free-icon/person-street-view-symbol_318-1051.jpg"
                },
                new Activity {
                    UserId = 9,
                    Description = "Your Facebook friend Tom K is on Instagram.",
                    ImageUrl = "https://image.freepik.com/free-icon/group-meeting_318-10037.jpg"
                },
            };

            //Binding
            viewCellListView.ItemsSource = contacts;
        }

        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var activity = e.SelectedItem as Activity;
            var userProfile = _users.FirstOrDefault(s => s.Id == activity.UserId);
            await Navigation.PushAsync(new ProfileDetailPage(userProfile));

            viewCellListView.SelectedItem = null;
        }
    }
}