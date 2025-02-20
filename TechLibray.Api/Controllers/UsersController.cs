using Microsoft.AspNetCore.Mvc;
using TechLibrary.Communication.Request;
using TechLibrary.Communication.Responses;
using TechLibrary.Exception;
using TechLibray.Api.UseCases.Users.Register;

namespace TechLibray.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterUsersJson),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagensJson), StatusCodes.Status400BadRequest)]
        public IActionResult Create(RequestUserJson request)
        {
            try
            {
                var useCase = new RegisterUserUseCase();
                var response = useCase.Execute(request);

                return Created(string.Empty, response);
            }
            catch (TechLibraryException ex)
            {
                return BadRequest(new ResponseErrorMessagensJson
                {
                    Errors = ex.GetErrorMessages()
                });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMessagensJson
                 {
                    Errors = { "Internal server error" } 
                });
            }
        }
    }
}
