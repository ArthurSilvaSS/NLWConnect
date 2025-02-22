using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TechLibrary.Communication.Responses;
using TechLibrary.Exception;

namespace TechLibray.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is TechLibraryException techLibraryException)
        {
            context.HttpContext.Response.StatusCode = (int) techLibraryException.GetStatusCode();
            context.Result = new ObjectResult(new ResponseErrorMessagensJson
            {
                Errors = techLibraryException.GetErrorMessages()
            });
        }

        else
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorMessagensJson
            {
                Errors = { "Internal server error" }
            });
        }
    }
}
