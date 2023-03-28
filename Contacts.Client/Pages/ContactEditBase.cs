using Contacts.Client.Services;
using Contacts.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Client.Pages
{
    //a class that communicates with service which is calling API and is implementing editing a contact by user
    public class ContactEditBase : ComponentBase
    {
        [Parameter]
        public string Email { get; set; }

        [Inject]
        public IContactService ContactService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        // A property to hold the contact to add
        public Contact Contact { get; set; } = new Contact();

        [Inject]
        public ICategoryService CategoryService { get; set; }

        public List<Category> CategoryList { get; set; } = new List<Category>();

        [Inject]
        public ISubcategoryService SubcategoryService { get; set; }

        public List<Subcategory> SubcategoryList { get; set; } = new List<Subcategory>();

        // A property to store authorized value if the user is logged 
        public string Logged { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        // This method is called when the component is initialized
        protected override async Task OnInitializedAsync()
        {
            // Getting the contacts, categories and subcategories from the database
            Contact = await ContactService.GetContact(Email);
            CategoryList = (await CategoryService.GetCategories()).ToList();
            SubcategoryList = (await SubcategoryService.GetSubcategories()).ToList();
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
            // Setting the subcategory to the first one in the list if none is selected
            if (Contact.Subcategory_name == "")
                Contact.Subcategory_name = SubcategoryList[0].name;

            var result = await ContactService.UpdateContact(Contact);

            if (result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
