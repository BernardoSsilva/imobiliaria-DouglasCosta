using System.Net;

namespace ImmobileApp.Exception
{
    public class UnauthorizedException : ImmobileAppException
    {
        private readonly string message;

        public UnauthorizedException():base(string.Empty)
        {
            message = "Unauthorized";
        }
        public override List<string> getErrorMessages()
        {
            return [message];
        }

        public override HttpStatusCode getStatusCode()
        {
            return HttpStatusCode.Unauthorized;
        }
    }
}
