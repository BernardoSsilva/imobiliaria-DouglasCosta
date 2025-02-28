using System.Net;

namespace ImmobileApp.Exception
{
    public class NotFoundException : ImmobileAppException
    {
        private readonly string _message;

        public NotFoundException():base(string.Empty)
        {
            _message = "Not Found";
        }
      
        public override List<string> getErrorMessages()
        {
            return [_message];
        }

        public override HttpStatusCode getStatusCode()
        {
            return HttpStatusCode.NotFound;
        }
    }
}
