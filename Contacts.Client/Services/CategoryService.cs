using Contacts.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Contacts.Client.Services
{
    //a class to communicate with API about category table in database
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient httpClient;

        public CategoryService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await httpClient.GetFromJsonAsync<Category[]>("api/categories");
        }
    }
}
