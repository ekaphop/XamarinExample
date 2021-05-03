using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinExample.Models;
using XamarinExample.ViewModels;

namespace XamarinExample.Views.Lesson9
{
    public partial class PlaylistsPage : ContentPage
    {
        public PlaylistsPage()
        {
            ViewModel = new PlaylistsViewModel(new PageService());

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            //ViewModel.LoadPlaylistCommand.Execute();
            base.OnAppearing();
        }

        void OnPlaylistSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Not clean
            //(BindingContext as PlaylistsViewModel).SelectPlaylistCommand.Execute(e.SelectedItem);

            // Clean
            ViewModel.SelectPlaylistCommand.Execute(e.SelectedItem);
        }

        public PlaylistsViewModel ViewModel
        {
            get { return BindingContext as PlaylistsViewModel; }
            set { BindingContext = value; }
        }
    }
}
