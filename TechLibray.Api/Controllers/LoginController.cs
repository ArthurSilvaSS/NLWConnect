using Microsoft.AspNetCore.Mvc;
using TechLibrary.Communication.Request;
using TechLibrary.Communication.Responses;
using TechLibray.Api.UseCases.Login.DoLogin;

namespace TechLibray.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterUsersJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorMessagensJson), StatusCodes.Status401Unauthorized)]
    public IActionResult DoLogin(RequestLoginJson request)
    {
        var useCase = new DoLoginUserCase();
        var response = useCase.Execute(request);

        return Ok(response);
    }
}
