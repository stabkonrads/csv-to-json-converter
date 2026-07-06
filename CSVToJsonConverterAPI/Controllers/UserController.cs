using CSVToJsonConverterAPI.Exceptions;
using CSVToJsonConverterAPI.Services;
using CSVToJsonConverterAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi;
using System.Text.Json.Nodes;

namespace CSVToJsonConverterAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
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
                JsonArray result = _userService.GetUsersFromRepo();

                // If the file is empty or no rows are found return 204 No Content
                if (result.Count < 1)
                    return NoContent();

                // TODO update the controller to return the result.
                return Ok(result);
            }

            catch (FileIsEmptyException)
            {
                // If the file is empty or no rows are found return 204 No Content
                return NoContent();
            }
            
            catch (FileNotFoundException)
            {
                // If file not found return 500 Internal Server Error
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            catch (Exception)
            {
                // If content file not found exception return 500
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
