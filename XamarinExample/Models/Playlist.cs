using System;
using Xamarin.Forms;
using XamarinExample.ViewModels;

namespace XamarinExample.Models
{
    public class Playlist : BaseViewModel
    {
		public string Title { get; set; }
		public bool IsFavorite { get; set; }
	}
}
