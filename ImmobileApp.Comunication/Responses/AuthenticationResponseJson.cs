using ImmobileApp.Comunication.Responses.ShortResponses;

namespace ImmobileApp.Comunication.Responses
{
    public class AuthenticationResponseJson
    {
        public string Token { get; set; } = string.Empty;
        public UserShortResponseJson User { get; set; } = null!;
    }
}
