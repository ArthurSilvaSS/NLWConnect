using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechLibrary.Api.Services.LoggedUser;
using TechLibray.Api.UseCases.Checkout;

namespace TechLibray.Api.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize]
public class CheckoutController : ControllerBase
{
    [HttpPost]
    [Route("{bookId}")]
    public ActionResult BookCheckout( Guid bookId) 
    {
        var loggedUser = new LoggedUserService(HttpContext);
        var useCase = new RegisterBookCheckoutUseCase(loggedUser);
        useCase.Execute(bookId);

        return NoContent();
    }
}