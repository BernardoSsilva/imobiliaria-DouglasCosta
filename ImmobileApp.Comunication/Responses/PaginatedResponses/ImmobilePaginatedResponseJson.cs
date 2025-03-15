using ImmobileApp.Comunication.Requests;
using ImmobileApp.Comunication.Responses.ShortResponses;

namespace ImmobileApp.Comunication.Responses.PaginatedResponses
{
    public class ImmobilePaginatedResponse
    {
        public PaginationParams paginationParams { get; set; } = null!;
        public List<ImmobileShortResponseJson> immobiles { get; set; } = [];
    }
}