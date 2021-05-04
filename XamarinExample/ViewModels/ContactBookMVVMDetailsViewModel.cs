using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinExample.Models;

namespace XamarinExample.ViewModels
{
    public class ContactBookMVVMDetailsViewModel
    {
        private readonly IContactStore _contactStore;
        private readonly IPageService _pageService;

        private string _commandType = "";
        private int _Id = 0;

        public event EventHandler<ContactBookMVVM> ContactBookEvent;

        public ContactBookMVVM ContactBookData { get; set; }

        public ICommand SaveCommand { get; set; }

        public ContactBookMVVMDetailsViewModel(ContactBookMVVMViewModel vm, IContactStore contactStore, IPageService pageService)
        {
            _pageService = pageService;
            _contactStore = contactStore;


			ContactBookData = new ContactBookMVVM
			{
				Id = vm.Id,
				FirstName = vm.FirstName,
				LastName = vm.LastName,
				PhoneNumber = vm.PhoneNumber,
				EmailAddress = vm.EmailAddress,
				IsBlocked = vm.IsBlocked,
				CanSave = vm.CanSave
			};

			SaveCommand = new Command(async () => await SaveMethod());
        }

		private async Task SaveMethod()
		{
			if (string.IsNullOrWhiteSpace(ContactBookData.FirstName) &&
                string.IsNullOrWhiteSpace(ContactBookData.LastName))
			{
				_pageService.DisplayAlert("Error", "Please enter the name.", "OK");
				return;
			}

			if (ContactBookData.Id == 0)
			{
				await _contactStore.AddContact(ContactBookData);

				ContactBookEvent?.Invoke(this, ContactBookData);
			}
			else
			{
				await _contactStore.UpdateContact(ContactBookData);

				ContactBookEvent?.Invoke(this, ContactBookData);
			}

			await _pageService.PopAsync();
		}
	}
}
