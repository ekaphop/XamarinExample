using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinExample.ViewModels;

namespace XamarinExample.Views.Lesson9
{
    public partial class PlaylistDetailPage : ContentPage
    {
        private PlaylistViewModel _playlist;

        public PlaylistDetailPage(PlaylistViewModel playlist)
        {
            _playlist = playlist;
            InitializeComponent();
            title.Text = _playlist.Title;
        }
    }
}
