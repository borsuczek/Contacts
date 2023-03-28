using Contacts.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Contacts.Api.Controllers
{
    // This code defines a controller class named "CategoriesController" that handles HTTP requests and responses.
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        // method that handles GET requests to retrieve a list of categories with the help of class CategoryRepository
        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            // calling the "GetCategories" method of the "categoryRepository" instance
            try
            {
                // returning the result as an HTTP response with status code 200 (OK) if everything went as planned
                return Ok(await categoryRepository.GetCategories());
            }
            catch (Exception)
            {
                //throwing exeption and returning an HTTP response with status code 500 (Internal Server Error) if something went wrong
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving data");
            }
        }

    }
}
