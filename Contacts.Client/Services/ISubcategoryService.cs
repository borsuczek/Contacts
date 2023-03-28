using Contacts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Client.Services
{
    //interface for SubcategoryService class
    public interface ISubcategoryService
    {
        Task<IEnumerable<Subcategory>> GetSubcategories();
    }
}
