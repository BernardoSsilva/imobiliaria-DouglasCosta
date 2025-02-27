using System.Net;

namespace ImmobileApp.Exception
{
    public class ErrorOnValidationException : ImmobileAppException
    {
        private readonly List<string> _errors;

        public ErrorOnValidationException(List<string> ErrorMessages):base(string.Empty)
        {
            _errors = ErrorMessages;
        }
        public override List<string> getErrorMessages() => _errors;

        public override HttpStatusCode getStatusCode() => HttpStatusCode.BadRequest;
    }
}
