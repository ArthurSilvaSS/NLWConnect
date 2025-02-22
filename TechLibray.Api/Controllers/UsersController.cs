using Microsoft.AspNetCore.Mvc;
using TechLibrary.Communication.Request;
using TechLibrary.Communication.Responses;
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
        public IActionResult Register(RequestUserJson request)
        {
            var useCase = new RegisterUserUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
