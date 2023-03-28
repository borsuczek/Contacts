using Contacts.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Contacts.Api.Controllers
{
    // This code defines a controller class named "SubcategoriesController" that handles HTTP requests and responses.
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoriesController : ControllerBase
    {

        private readonly ISubcategoryRepository subcategoryRepository;
        public SubcategoriesController(ISubcategoryRepository subcategoryRepository)
        {
            this.subcategoryRepository = subcategoryRepository;
        }

        // method that handles GET requests to retrieve a list of subcategories with the help of class SubcategoryRepository
        [HttpGet]
        public async Task<ActionResult> GetSubcategories()
        {
            try
            {
                // returning the result as an HTTP response with status code 200 (OK) if everything went as planned
                return Ok(await subcategoryRepository.GetSubcategories());
            }
            catch (Exception)
            {
                // throwing exeption and returning an HTTP response with status code 500(Internal Server Error) if something went wrong
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving data");
            }
        }
        
    }
}
