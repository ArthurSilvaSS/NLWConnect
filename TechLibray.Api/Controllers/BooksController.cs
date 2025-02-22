using Microsoft.AspNetCore.Mvc;
using TechLibrary.Communication.Request;
using TechLibray.Api.UseCases.Books;

namespace TechLibray.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    [HttpGet("Filter")]
    public IActionResult Filter( int pageNumber, string? title)
    {
        var useCase = new FilterBookUseCase();

        var result = useCase.Execute(new RequestFilterBooksJson
        {
            PageNumber = pageNumber,
            Title = title
        });

        return Ok(result);

    }
}

