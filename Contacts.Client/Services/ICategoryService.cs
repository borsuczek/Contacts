using Contacts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Client.Services
{
    //interface for CategoryService class
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategories();
    }
}
