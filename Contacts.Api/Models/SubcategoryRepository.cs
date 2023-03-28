using Contacts.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Api.Models
{
    //A class for communicating with Subcategory database table
    public class SubcategoryRepository : ISubcategoryRepository
    {
        private readonly AppDbContext appDbContext;
        public SubcategoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Subcategory>> GetSubcategories()
        {
            return await appDbContext.Subcategories.ToListAsync();
        }
    }
}
