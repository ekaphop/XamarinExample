using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinExample.Models;
using XamarinExample.Services;

namespace XamarinExample.Views.Section5
{
    public partial class AirbnbPage : ContentPage
    {
        private SearchService _searchService;
        private List<SearchGroup> _searchGroups;

        public AirbnbPage()
        {
            InitializeComponent();
            _searchService = new SearchService();
            PopulateListView(_searchService.GetRecentSearches());
        }

        private void PopulateListView(IEnumerable<Search> searches)
        {
            _searchGroups = new List<SearchGroup>
            {
                new SearchGroup("Recent Searches", searches)
            };

            listView.ItemsSource = _searchGroups;
        }

		private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
		{
			PopulateListView(_searchService.GetRecentSearches(e.NewTextValue));
		}

		private void OnDeleteClicked(object sender, EventArgs e)
		{
			var search = (sender as MenuItem).CommandParameter as Search;
			_searchGroups[0].Remove(search);
			_searchService.DeleteSearch(search.Id);
		}

		private void OnRefreshing(object sender, EventArgs e)
		{
			PopulateListView(_searchService.GetRecentSearches(searchBar.Text));

			listView.EndRefresh();
		}

		private void OnSearchSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var search = e.SelectedItem as Search;
			DisplayAlert("Selected", search.Location, "OK");
		}
	}
}
