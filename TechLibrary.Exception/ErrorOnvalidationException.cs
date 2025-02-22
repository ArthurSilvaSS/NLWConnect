using System.Net;

namespace TechLibrary.Exception
{
    public class ErrorOnvalidationException : TechLibraryException
    {
        private readonly List<string> _erros;
        public ErrorOnvalidationException(List<string> errorMessages) : base(string.Empty)
        {
            _erros = errorMessages;
        }
        public override List<string> GetErrorMessages() => _erros;
        public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
    }
}
