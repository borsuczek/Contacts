using Contacts.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Contacts.Client.Services
{
    //a class to communicate with API about cubcategory table in database
    public class SubcategoryService : ISubcategoryService
    {
        private readonly HttpClient httpClient;

        public SubcategoryService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Subcategory>> GetSubcategories()
        {
            return await httpClient.GetFromJsonAsync<Subcategory[]>("api/subcategories");
        }
    }
}
