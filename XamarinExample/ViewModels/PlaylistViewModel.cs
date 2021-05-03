using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using XamarinExample.Models;

namespace XamarinExample.ViewModels
{
    public class PlaylistViewModel : BaseViewModel
    {
		public string Title { get; set; }

		private bool _isFavorite;
		public bool IsFavorite
		{
			get { return _isFavorite; }
			set
			{
				SetValue(ref _isFavorite, value);
				OnPropertyChanged(nameof(Color));
			}
		}

		public Color Color
		{
			get { return IsFavorite ? Color.Pink : Color.Black; }
		}
	}
}
