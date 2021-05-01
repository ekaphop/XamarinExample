using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using XamarinExample.Models;

namespace XamarinExample.Views.Section5
{
    public partial class HotelBookingPage : ContentPage
    {
        private ObservableCollection<HotelBooking> _bookings;
        public ObservableCollection<HotelBooking> Bookings
        {
            get
            {
                return _bookings;
            }
            set
            {
                if (_bookings != value)
                {
                    _bookings = value;
                    OnPropertyChanged(nameof(Bookings));
                }
            }
        }

        public HotelBookingPage()
        {
            InitializeComponent();

            Bookings = new ObservableCollection<HotelBooking>
            {
                new HotelBooking{
                    BookingAddress="West Hollyword, CA, United States",
                    BookingDate="Sep 1,2016 - Nov 1,2016"},
                new HotelBooking{
                    BookingAddress="Santa Monica, CA, United States",
                    BookingDate="Sep 1,2016 - Nov 1,2016"}
            };

            //Binding
            textCellListView.ItemsSource = Bookings;
        }

        void DeleteMenuItem_Clicked(object sender, EventArgs e)
        {
            var booking = (sender as MenuItem).CommandParameter as HotelBooking;
            Bookings.Remove(booking);
            searchbar.Text = "";
        }

        void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.NewTextValue))
                textCellListView.ItemsSource = Bookings.Where(s => s.BookingAddress.StartsWith(e.NewTextValue));
            else        
                textCellListView.ItemsSource = Bookings;
        }

        void ListView_Refreshing(object sender, EventArgs e)
        {
            textCellListView.ItemsSource = Bookings;
            textCellListView.EndRefresh();
        }
    }
}