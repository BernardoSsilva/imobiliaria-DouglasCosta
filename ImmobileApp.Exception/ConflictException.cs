using System.Net;

namespace ImmobileApp.Exception
{
    public class ConflictException : ImmobileAppException
    {
        private readonly string _message ;


        public ConflictException(string message):base(string.Empty)
        {
            _message = message;
        }
        
        public override List<string> getErrorMessages()
        {
            return [_message];
        }

        public override HttpStatusCode getStatusCode()
        {
            return HttpStatusCode.Conflict;
        }
    }
}
