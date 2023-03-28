using Contacts.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Contacts.Client.Services
{
    //interface for ContactService class
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetContacts();
        Task<Contact> GetContact(string email);
        Task<HttpResponseMessage> UpdateContact(Contact contact);
        Task<HttpResponseMessage> AddContact(Contact contact);
        Task DeleteContact(string email);
    }
}
