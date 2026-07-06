using CSVToJsonConverterAPI.Services;
using CSVToJsonConverterAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CSVToJsonConverterAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsers(int limit)
        {   
            // Checks if limit has a negative number and returns 400 Bad Request
            if (int.IsNegative(limit))
                return BadRequest();

            try
            {

                // TODO if the file is empty or no rows are found return 204 No Content
                // TODO update the controller to return the result.
                return Ok();
            }
            
            catch (Exception)
            {
                // TODO if file not found exception return 500
                return StatusCode(StatusCodes.Status500InternalServerError);
                throw;
            }
        }
    }
}
