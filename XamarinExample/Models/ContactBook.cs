using System;
namespace XamarinExample.Models
{
    public class ContactBook
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public bool IsBlocked { get; set; }
        public bool CanSave { get; set; }

        //Search from internet
        public string Fullname => $"{FirstName} {LastName}";

        public static implicit operator EventHandler<object>(ContactBook v)
        {
            throw new NotImplementedException();
        }
    }
}
