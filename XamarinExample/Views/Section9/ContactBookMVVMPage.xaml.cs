using Xamarin.Forms;
using XamarinExample.ViewModels;

namespace XamarinExample.Views.Section9
{
    public partial class ContactBookMVVMPage : ContentPage
    {
        public ContactBooksMVVMViewModel vm
        {
            get { return BindingContext as ContactBooksMVVMViewModel; }
            set { BindingContext = value; }
        }

        public ContactBookMVVMPage()
        {
            var contactStore  = new SQLiteContactStore();
            var pageService = new PageService();

            vm = new ContactBooksMVVMViewModel(contactStore, pageService); 

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            vm.GetAllContactCommand.Execute(null);

            base.OnAppearing();
        }

        void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            vm.SelectContactCommand.Execute(e.SelectedItem);
        }
    }
}