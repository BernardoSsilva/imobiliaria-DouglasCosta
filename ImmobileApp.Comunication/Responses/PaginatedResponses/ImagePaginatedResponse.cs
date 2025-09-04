using ImmobileApp.Comunication.Requests;
using ImmobileApp.Comunication.Responses.ShortResponses;

namespace ImmobileApp.Comunication.Responses.PaginatedResponses
{
    public class ImagePaginatedResponse
    {

        public PaginationParams paginationParams { get; set; } = null!;
        public List<ImageShortResponseJson> images { get; set; } = [];

        public int TotalAmount { get; set; }

        public int PageNumber { get; set; }
    }
}

