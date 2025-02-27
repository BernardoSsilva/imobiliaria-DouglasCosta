namespace ImmobileApp.Comunication.Responses.LongResponses
{
    public class UserLongResponseJson
    {
        public Guid Id { get; set; } = new Guid();
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string Role { get; set; } =string.Empty;
    }
}
