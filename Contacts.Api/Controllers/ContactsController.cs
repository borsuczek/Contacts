using Contacts.Api.Models;
using Contacts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Contacts.Api.Controllers
{
    // This code defines a controller class named "ContactsController" that handles HTTP requests and responses.
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository contactRepository;
        public ContactsController(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        // calling the "GetContacts" method of the "contactRepository" instance
        [HttpGet]
        public async Task<ActionResult> GetContacts()
        {
            try
            {
                // returning the result as an HTTP response with status code 200 (OK) if everything went as planned
                return Ok(await contactRepository.GetContacts());
            }
            catch (Exception)
            {
                // throwing exeption and returning an HTTP response with status code 500(Internal Server Error) if something went wrong
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving data");
            }
        }

        // calling the "GetContact" method of the "contactRepository" instance and returning found in database contact
        [HttpGet("{email}")]
        public async Task<ActionResult<Contact>> GetContact(string email)
        {
            try
            {
                //getting specific contact from database with the help of method GetContact from class ContactRepository
                var result = await contactRepository.GetContact(email);
                if (result == null)
                {
                    //returning HTTP response with status code 404(not found)
                    return NotFound();
                }
                //returning found contact
                return result;
            }
            catch (Exception)
            {
                // throwing exeption and returning an HTTP response with status code 500(Internal Server Error) if something went wrong
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving data");
            }
        }

        // calling the "AddContact" method of the "contactRepository" instance
        [HttpPost]
        public async Task<ActionResult<Contact>> AddContact(Contact contact)
        {
            try
            {
                //returning an HTTP response with status code 400 (bad request) if given contact is empty
                if (contact == null)
                {
                    return BadRequest();
                }

                //communicating with ContactRepository to add contact to database and retuning status code 201 (created)
                var newContact = await contactRepository.AddContact(contact);
                return CreatedAtAction(nameof(GetContact), new { email = newContact.Email }, newContact);
            }
            catch (Exception)
            {
                // throwing exeption and returning an HTTP response with status code 500(Internal Server Error) if something went wrong
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving data");
            }
        }

        // calling the "UpdateContact" method of the "contactRepository" instance
        [HttpPut()]
        public async Task<ActionResult<Contact>> UpdateContact(Contact contact)
        {
            try
            {
                //getting existing contact with the same email (id) as contact which is used as contact with updated values
                var contactToUpdate = await contactRepository.GetContact(contact.Email);

                //returning response that contact was not found in database and updating contact if everything went as planned
                if(contactToUpdate == null)
                {
                    return NotFound($"Contact with email {contact.Email} not found");
                }
                else
                    return await contactRepository.UpdateContact(contact);
            }
            catch (Exception)
            {
                // throwing exeption and returning an HTTP response with status code 500(Internal Server Error) if something went wrong
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while updating data");
            }
        }

        // calling the "DeleteContact" method of the "contactRepository" instance
        [HttpDelete("{email}")]
        public async Task<ActionResult<Contact>> DeleteContact(string email)
        {
            try
            {
                //searching for contact to  delete in database and giving not found respose if it is not present
                var result = await contactRepository.GetContact(email);
                if (result == null)
                {
                    return NotFound();
                } 
                //deleting contact
                return await contactRepository.DeleteContact(email);
            }
            catch (Exception)
            {
                // throwing exeption and returning an HTTP response with status code 500(Internal Server Error) if something went wrong
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving data");
            }
        }

    }
}
