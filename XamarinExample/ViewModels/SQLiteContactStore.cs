using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using XamarinExample.Models;
using XamarinExample.Persistence;

namespace XamarinExample.ViewModels
{
    public class SQLiteContactStore : IContactStore
    {
        private SQLiteAsyncConnection _connection;

        public SQLiteContactStore()
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            _connection.CreateTableAsync<ContactBookMVVM>();       
        }

        public async Task<IEnumerable<ContactBookMVVM>> GetAllContacts()
        {
            return await _connection.Table<ContactBookMVVM>().ToListAsync();
        }

        public async Task<ContactBookMVVM> GetContactById(int contactId)
        {
            return await _connection.FindAsync<ContactBookMVVM>(contactId);
        }

        public async Task AddContact(ContactBookMVVM contactBook)
        {
            await _connection.InsertAsync(contactBook);
        }

        public async Task UpdateContact(ContactBookMVVM contactBook)
        {
            await _connection.UpdateAsync(contactBook);
        }

        public async Task DeleteContact(ContactBookMVVM contactBook)
        {
            await _connection.DeleteAsync(contactBook);
        }
    }
}
