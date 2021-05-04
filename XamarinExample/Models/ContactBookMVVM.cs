using System;
using SQLite;

namespace XamarinExample.Models
{
    public class ContactBookMVVM
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public bool IsBlocked { get; set; }
        public bool CanSave { get; set; }
    }
}
