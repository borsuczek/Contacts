using Contacts.Client.Services;
using Contacts.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Contacts.Client.Pages
{
    //a class that communicates with service which is calling API and is implementing logging in a user
    public class LoginUserBase : ComponentBase
    {
        [Inject]
        public IContactService ContactService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public bool ok { get; set; } = true;

        public LoginInfo LoginData { get; set; } = new LoginInfo();

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        // A property to store authorized value if the user is logged 
        public string Logged { get; set; }

        // This method is called when the component is initialized
        protected override async Task OnInitializedAsync()
        {
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

        protected async Task Submit()
        {
            var contact = await ContactService.GetContact(LoginData.Email);
            //nagivating to other pages depending on result and checking if password matches sign in contact password
            if (contact == null || LoginData.Password != contact.Password)
            {
                LoginData.Email = "";
                LoginData.Password = "";
                ok = false;
                NavigationManager.NavigateTo("/login/error");
            }
            else 
            {
                string message = "authorized";
                await JSRuntime.InvokeVoidAsync("eval", $"document.cookie = \"{message}\"");
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
