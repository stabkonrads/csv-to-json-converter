using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CSVToJsonConverterAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet()]
        public async Task<IActionResult> GetUsers(int limit)
        {
            
            if (int.IsNegative(limit))
                return BadRequest();

            try
            {

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
