using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinExample.Models;

namespace XamarinExample.ViewModels
{
    public interface IContactStore
    {
        Task<IEnumerable<ContactBookMVVM>> GetAllContacts();
        Task<ContactBookMVVM> GetContactById(int id);
        Task AddContact(ContactBookMVVM contact);
        Task UpdateContact(ContactBookMVVM contact);
        Task DeleteContact(ContactBookMVVM contact);
    }
}
