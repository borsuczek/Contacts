using Contacts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;

namespace Contacts.Client.Services
{
    //a class to communicate with API about contact table in database
    public class ContactService : IContactService
    {
        private readonly HttpClient httpClient;

        public ContactService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Contact> GetContact(string email)
        {
            return await httpClient.GetFromJsonAsync<Contact>($"api/contacts/{email}");
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await httpClient.GetFromJsonAsync<Contact[]>("api/contacts");
        }

        public async Task<HttpResponseMessage> UpdateContact(Contact contact)
        {
            return await httpClient.PutAsJsonAsync<Contact>($"api/contacts", contact);
        }

        public async Task<HttpResponseMessage> AddContact(Contact contact)
        {
            return await httpClient.PostAsJsonAsync<Contact>($"api/contacts", contact);
        }

        public async Task DeleteContact(string email)
        {
            await httpClient.DeleteAsync($"api/contacts/{email}");
        }
    }
}
