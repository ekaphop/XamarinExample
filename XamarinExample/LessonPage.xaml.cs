using System;

using Xamarin.Forms;
using XamarinExample.Views.Lesson5;
using XamarinExample.Views.Lesson6;
using XamarinExample.Views.Lesson7;
using XamarinExample.Views.Lesson8;

namespace XamarinExample
{
    public partial class LessonPage : ContentPage
    {
        public LessonPage()
        {
            InitializeComponent();
        }

        #region ----- Lesson 5 : Lists -----
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
        #endregion

        #region ----- Lesson 6 : Navigation -----
        async void Welcome_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WelcomePage());
        }

        async void MasterDetail_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SimpleMasterPage());
        }

        async void TabbedPage_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MasterTabbedPage());
        }
        #endregion

        #region ----- Lesson 7 : Forms and Setting Pages -----
        async void Lesson7Demo_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Lesson7DemoPage());
        }

        async void TableView_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TableViewPage());
        }
        #endregion

        #region ----- Lesson 8 : Data Access -----
        async void UsingSQLite_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UsingSQLitePage());
        }

        async void UsingRestful_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UsingRestfullPage());
        }
        
        #endregion
    }
}
