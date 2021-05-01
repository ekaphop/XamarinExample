using System;

using Xamarin.Forms;
using XamarinExample.Views.Lesson5;

namespace XamarinExample
{
    public partial class LessonPage : ContentPage
    {
        public LessonPage()
        {
            InitializeComponent();
        }

        async void BasicList_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BasicListPage());
        }

        async void CellAppearance_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CellAppearancePage());
        }

        async void GroupingItems_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GroupingItemsPage());
        }

        async void TextCellContextAction_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContextActionPage());
        }

        async void ListViewRefreshing_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PullToRefreshPage());
        }

        async void Searchbar_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListViewSearchBarPage());
        }
    }
}
