using Contacts.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Api.Models
{
    //A class for communicating with Category database table
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext appDbContext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            // Access the "Categories" table in the "appDbContext" instance and return its content as a list
            return await appDbContext.Categories.ToListAsync();
        }
    }
}
