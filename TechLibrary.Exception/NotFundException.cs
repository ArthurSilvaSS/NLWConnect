using System.Net;

namespace TechLibrary.Exception;

public class NotFundException : TechLibraryException
{
    public NotFundException(string message) : base(message) { }
    public override List<string> GetErrorMessages() => [Message];

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.NotFound;

}
