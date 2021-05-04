using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinExample.Views.Section9;

namespace XamarinExample.ViewModels
{
    public class ContactBooksMVVMViewModel : BaseViewModel
    {
        private IContactStore _contactStore;
        private IPageService _pageService;
        private bool _isLoadCompleted = false;

        public ObservableCollection<ContactBookMVVMViewModel> ContactBooks { get; set; }
               = new ObservableCollection<ContactBookMVVMViewModel>();

        public ICommand GetAllContactCommand { get; private set; }
        public ICommand AddContactCommand { get; private set; }
        public ICommand SelectContactCommand { get; private set; }
        public ICommand DeleteContactCommand { get; private set; }

        public ContactBooksMVVMViewModel(
            IContactStore contactStore,
            IPageService pageService)
        {
            _contactStore = contactStore;
            _pageService = pageService;

            GetAllContactCommand = new Command(async () => await GetAllContactMethod());
            AddContactCommand = new Command(async () => await AddContactMethod());
            SelectContactCommand = new Command<ContactBookMVVMViewModel>(async sc => await SelectContactMethod(sc));
            DeleteContactCommand = new Command<ContactBookMVVMViewModel>(async dc => await DeleteContactMethod(dc));
        }

        private async Task GetAllContactMethod()
        {
            if (!_isLoadCompleted)
            {
                return; //exit
            }
                
            var contactBooks = await _contactStore.GetAllContacts();

            foreach(var contact in contactBooks)
            {
                ContactBooks.Add(new ContactBookMVVMViewModel(contact));
            }
        }

        private async Task AddContactMethod()
        {
            var vm = new ContactBookMVVMDetailsViewModel(new ContactBookMVVMViewModel(), _contactStore, _pageService);

            vm.ContactBookEvent += (source, contact) =>
            {
                ContactBooks.Add(new ContactBookMVVMViewModel(contact));
            };

            await _pageService.PushAsync(new ContactBookMVVMDetailsPage(vm));
        }

        private async Task SelectContactMethod(ContactBookMVVMViewModel contact)
        {
            if (contact == null)
                return;

            var vm = new ContactBookMVVMDetailsViewModel(contact, _contactStore, _pageService);
            vm.ContactBookEvent += (source, updatedContact) =>
            {
                contact.Id = updatedContact.Id;
                contact.FirstName = updatedContact.FirstName;
                contact.LastName = updatedContact.LastName;
                contact.PhoneNumber = updatedContact.PhoneNumber;
                contact.EmailAddress = updatedContact.EmailAddress;
                contact.IsBlocked = updatedContact.IsBlocked;
            };

            await _pageService.PushAsync(new ContactBookMVVMDetailsPage(vm));
        }

        private async Task DeleteContactMethod(ContactBookMVVMViewModel contackBook)
        {
            var deleteMessage = "Are you sure you want to delete " + contackBook.Fullname;
            var response = await _pageService.DisplayAlert("Warning", deleteMessage, "Yes", "No");

            if (response) //User click Yes
            {
                ContactBooks.Remove(contackBook);

                var contactData = await _contactStore.GetContactById(contackBook.Id);
                await _contactStore.DeleteContact(contactData);
            }
        }
    }
}