using System.Net;

namespace ImmobileApp.Comunication.Errors
{
    public class ErrorOnValidationJson
    {
        public List<string> Messages { get; set; } = [];
        public HttpStatusCode StatusCode { get; set; }
    }
}
