using System;
using System.Collections.ObjectModel;
using SQLite;
using Xamarin.Forms;
using XamarinExample.Models;
using XamarinExample.Persistence;

namespace XamarinExample.Views.Lesson8
{
    public partial class UsingSQLitePage : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<Recipe> _recipes;

        public UsingSQLitePage()
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<Recipe>();

            var recipes = await _connection.Table<Recipe>().ToListAsync();
            _recipes = new ObservableCollection<Recipe>(recipes);
            recipesListView.ItemsSource = _recipes;

            base.OnAppearing();
        }

        async void OnAdd(object sender, EventArgs e)
        {
            var recipe = new Recipe { Name = "Recipe "+ DateTime.Now.Ticks};
            await _connection.InsertAsync(recipe);
            _recipes.Add(recipe);
        }

        async void OnUpdate(object sender, EventArgs e)
        {
            var recipe = _recipes[0];
            recipe.Name += " Update";
            await _connection.UpdateAsync(recipe);
        }

        async void OnDelete(object sender, EventArgs e)
        {
            var recipe = _recipes[0];
            await _connection.DeleteAsync(recipe);
            _recipes.Remove(recipe);
        }
    }
}
