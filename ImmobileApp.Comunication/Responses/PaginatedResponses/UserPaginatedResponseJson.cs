using ImmobileApp.Comunication.Requests;
using ImmobileApp.Comunication.Responses.ShortResponses;

namespace ImmobileApp.Comunication.Responses.PaginatedResponses
{
    public class UserPaginatedResponseJson
    {
        public List<UserShortResponseJson> Users { get; set; } = [];
        public PaginationParams PaginationParams { get; set; } = null!;
    }
}
