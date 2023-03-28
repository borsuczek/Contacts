using Contacts.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Api.Models
{
    //A class for communicating with Contact database table
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext appDbContext;
        public ContactRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        //a method adding contact to the Contact table
        public async Task<Contact> AddContact(Contact contact)
        {
            var result = await appDbContext.Contacts.AddAsync(contact);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        //a method deleting specific contact from the Contact table
        public async Task<Contact> DeleteContact(string email)
        {
            var result = await appDbContext.Contacts.FirstOrDefaultAsync(c => c.Email == email);
            //deleting contact only if it is found in the database
            if(result != null)
            {
                appDbContext.Contacts.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
            return result;
        }

        //a method that returns contact from database table with given email (key)
        public async Task<Contact> GetContact(string email)
        {
            return await appDbContext.Contacts.FirstOrDefaultAsync(c => c.Email == email);
        }

        //a method returning all contacts as a list of Contact classes
        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await appDbContext.Contacts.ToListAsync();
        }

        //a method updating a contact in the database, contact that is given as parameter is with new values
        //despite email address, it is id and it is not changing
        public async Task<Contact> UpdateContact(Contact contact)
        {
            //getting contact that have the same email address as updated
            var result = await appDbContext.Contacts.FirstOrDefaultAsync(c => c.Email == contact.Email);

            //changing values of original contact to updated
            if(result != null)
            {
                result.Name = contact.Name;
                result.Surname = contact.Surname;
                result.Email = contact.Email;
                result.Category_type = contact.Category_type;
                result.Subcategory_name = contact.Subcategory_name;
                result.Password = contact.Password;
                result.Phone = contact.Phone;
                result.Birth_date = contact.Birth_date;

                //saving changes in the database
                await appDbContext.SaveChangesAsync();
            }

            return result;
        }
    }
}
