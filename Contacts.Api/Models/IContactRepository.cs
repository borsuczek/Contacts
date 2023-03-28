using Contacts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Api.Models
{
    //interface for ContactRepository class
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetContacts();
        Task<Contact> GetContact(string email);
        Task<Contact> AddContact(Contact contact);
        Task<Contact> UpdateContact(Contact contact );
        Task<Contact> DeleteContact(string email);
    }
}
