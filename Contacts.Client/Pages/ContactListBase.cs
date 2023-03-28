using Contacts.Client.Services;
using Contacts.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Client.Pages
{
    //a class that communicates with service which is calling API and is implementing displaying list of contacts to a user
    public class ContactListBase : ComponentBase
    {
        [Inject]
        public IContactService ContactService { get; set; }

        public IEnumerable<Contact> Contacts { get; set; }

        public Contact Contact { get; set; } = new Contact();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        // A property to store authorized value if the user is logged 
        public string Logged { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        // This method is called when the component is initialized
        protected override async Task OnInitializedAsync()
        {
            // Getting the contacts from the database
            Contacts = (await ContactService.GetContacts()).ToList();
            try
            {
                // Checking if the user is logged in by reading the cookie
                Logged = await JSRuntime.InvokeAsync<string>("eval", $"document.cookie");
            }
            catch
            {
                Logged = "";
            }
        }

        protected async Task Delete()
        {
            //checking if a contact list have more than one contact, there always have to be a person that can log in
            Contacts = (await ContactService.GetContacts()).ToList();
            if (Contacts.Count() > 1)
            {
                await ContactService.DeleteContact(Contact.Email);
                await OnInitializedAsync();
            }
            else
            {
                NavigationManager.NavigateTo("delete/error");
            }
        }

        protected void Edit()
        {
            NavigationManager.NavigateTo($"edit/{Contact.Email}");
        }

        protected void LogIn()
        {
            NavigationManager.NavigateTo("login");
        }

        protected async void LogOut()
        {
            string message = "not";
            //changing cookie to user not being logged
            await JSRuntime.InvokeVoidAsync("eval", $"document.cookie = \"{message}\"");
            NavigationManager.NavigateTo($"logout");
        }
    }
}
