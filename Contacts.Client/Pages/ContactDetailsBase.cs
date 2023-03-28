using Contacts.Client.Services;
using Contacts.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Contacts.Client.Pages
{
    //a class that communicates with service which is calling API and is implementing displaying contact details to a user
    public class ContactDetailsBase : ComponentBase
    {
        [Parameter]
        public string Email { get; set; }

        [Inject]
        public IContactService ContactService { get; set; }

        public Contact Contact { get; set; } = new Contact();

        protected override async Task OnInitializedAsync()
        {
            Contact = await ContactService.GetContact(Email);
        }
    }
}
