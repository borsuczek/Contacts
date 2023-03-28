using Contacts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Api.Models
{
    //interface for SubcategoryRepository class
    public interface ISubcategoryRepository
    {
        Task<IEnumerable<Subcategory>> GetSubcategories();
    }
}
