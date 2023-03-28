using Contacts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Api.Models
{
    //interface for CategoryRepository class
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
    }
}
